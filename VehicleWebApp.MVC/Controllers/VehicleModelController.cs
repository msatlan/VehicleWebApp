using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;
using VehicleWebApp.Service.Models.Common.APIErrors;
using VehicleWebApp.Service.Services.Common;

namespace VehicleWebApp.MVC.Controllers
{
    [Route("/api/vehicleModels")]
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] QueryViewModel viewModel)
        {
            var pagingModel = _mapper.Map<QueryViewModel, PagingModel>(viewModel);
            var filteringModel = _mapper.Map<QueryViewModel, FilteringModel>(viewModel);
            var sortingModel = _mapper.Map<QueryViewModel, SortingModel>(viewModel);

            var vehicleModels = await _vehicleModelService.ListAsync(pagingModel, sortingModel, filteringModel);

            var vehicleModelViewModel = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelViewModel>>(vehicleModels);

            var jsonResponse = new
            {
                data = vehicleModelViewModel,
                queryParams = new
                {
                    pageNo = vehicleModels.CurrentPage,
                    totalPages = vehicleModels.TotalPages,
                    hasNextPage = vehicleModels.HasNextPage,
                    hasPreviousPage = vehicleModels.HasPreviousPage,
                    currentFilter = filteringModel.Filter ?? "none",
                    sortOrder = sortingModel.SortBy ?? "id"
                }
            };

            return Ok(jsonResponse);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VehicleModelViewModel vehicleModelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleModelToSave = _mapper.Map<VehicleModelViewModel, VehicleModel>(vehicleModelViewModel);

            var result = await _vehicleModelService.InsertAsync(vehicleModelToSave);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleModelViewModel vehicleModelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            Debug.WriteLine(vehicleModelViewModel.Make);
            Debug.WriteLine(vehicleModelViewModel.MakeId);

            var vehicleModelToUpdate = _mapper.Map<VehicleModelViewModel, VehicleModel>(vehicleModelViewModel);

            var result = await _vehicleModelService.UpdateAsync(id, vehicleModelToUpdate);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }

        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteAsync(Guid? id)
        {
            var result = await _vehicleModelService.DeleteAsync(id);

            if (!result.Success)
            {
                switch (result.ErrorType)
                {
                    case ErrorType.BadRequest:
                        return BadRequest(new BadRequestError(result.Message));

                    case ErrorType.NotFound:
                        return NotFound(new NotFoundError(result.Message));

                    case ErrorType.Other:
                        return BadRequest(new BadRequestError(result.Message));

                    default:
                        break;
                }
            }

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }
    }
}
