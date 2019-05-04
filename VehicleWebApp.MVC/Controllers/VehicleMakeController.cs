using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;
using VehicleWebApp.Service.Models.Common.APIErrors;
using VehicleWebApp.Service.Repositories.Common;
using VehicleWebApp.Service.Services.Common;

namespace VehicleWebApp.MVC.Controllers
{
    [Route("/api/vehicleMakes")]
    public class VehicleMakeController : Controller
    {
        // Added with dependency injection 
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IMapper _mapper;

        // Constructor
        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper, IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeService = vehicleMakeService;
            _vehicleMakeRepository = vehicleMakeRepository;
            _mapper = mapper;
        }

        // Get request
        //             * results on 1 page: https://localhost:44391/api/vehicleMakes  
        //                 * paged results: https://localhost:44391/api/vehicleMakes?currentPage=(int)&objectsPerPage=(int)
        //         * sorted results 1 page: https://localhost:44391/api/vehicleMakes?sortBy=(string)
        //          * sorted paged results: https://localhost:44391/api/vehicleMakes?sortBy=(string)&currentPage=(int)&objectsPerPage=(int)
        //       * filtered results 1 page: https://localhost:44391/api/vehicleMakes?filter=(string)
        //        * filtered paged results: https://localhost:44391/api/vehicleMakes?filter=(string)&currentPage=(int)&objectsPerPage=(int)
        // * filtered sorted paged results: https://localhost:44391/api/vehicleMakes?filter=(string)&sortby=(string)&currentPage=(int)&objectsPerPage=(int)

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] QueryViewModel viewModel)
        {
            var pagingModel = _mapper.Map<QueryViewModel, PagingModel>(viewModel);
            var filteringModel = _mapper.Map<QueryViewModel, FilteringModel>(viewModel);
            var sortingModel = _mapper.Map<QueryViewModel, SortingModel>(viewModel);

            var vehicleMakes = await _vehicleMakeService.ListAsync(pagingModel, sortingModel, filteringModel);

            var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

            var jsonResponse = new
            {
                data = vehicleMakeViewModel,
                queryParams = new
                {
                    pageNo = vehicleMakes.CurrentPage,
                    totalPages = vehicleMakes.TotalPages,
                    hasNextPage = vehicleMakes.HasNextPage,
                    hasPreviousPage = vehicleMakes.HasPreviousPage,
                    currentFilter = filteringModel.Filter ?? "none",
                    sortOrder = sortingModel.SortBy ?? "id"
                }
            };

            return Ok(jsonResponse);
         }

        // Post request
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] VehicleMakeViewModel vehicleMakeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));
            
            var vehicleMake = _mapper.Map<VehicleMakeViewModel, VehicleMake>(vehicleMakeViewModel);

            var result = await _vehicleMakeService.InsertAsync(vehicleMake);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }
        
        // Put request
        [HttpPut("{id?}")]
        public async Task<IActionResult> PutAsync(Guid? id, [FromBody] VehicleMakeViewModel vehicleMakeViewModel) 
        {
            if (id == null) return BadRequest(new BadRequestError("Id is null or of wrong type, please enter a valid Id"));

            var vehicleMake = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMake == null)
            {
                var errorResult = await _vehicleMakeService.UpdateAsync(null);

                if (!errorResult.Success) return BadRequest(new BadRequestError(errorResult.Message));
            }

            if (string.IsNullOrEmpty(vehicleMakeViewModel.Name)) return BadRequest(new BadRequestError("Name field is required"));

            vehicleMake = _mapper.Map<VehicleMakeViewModel, VehicleMake>(vehicleMakeViewModel);

            var result = await _vehicleMakeService.UpdateAsync(vehicleMake);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }

        // Delete request
        [HttpDelete("{id?}")]
        public async Task<IActionResult> DeleteAsync(Guid? id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

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

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }
    }
}
