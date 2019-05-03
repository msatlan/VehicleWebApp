using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;
using VehicleWebApp.Service.Models.Common.APIErrors;
using VehicleWebApp.Service.Services.Common;

namespace VehicleWebApp.MVC.Controllers
{
    [Route("/api/vehicleMakes")]
    public class VehicleMakeController : Controller
    {
        // Added with dependency injection 
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        // Constructor
        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        // Get request
        //             * results on 1 page: https://localhost:44391/api/vehicleMakes/get  
        //                 * paged results: https://localhost:44391/api/vehicleMakes/get?currentPage=(int)&objectsPerPage=(int)
        //         * sorted results 1 page: https://localhost:44391/api/vehicleMakes/get?sortBy=(string)
        //          * sorted paged results: https://localhost:44391/api/vehicleMakes/get?sortBy=(string)&currentPage=(int)&objectsPerPage=(int)
        //       * filtered results 1 page: https://localhost:44391/api/vehicleMakes/get?filter=(string)
        //        * filtered paged results: https://localhost:44391/api/vehicleMakes/get?filter=(string)&currentPage=(int)&objectsPerPage=(int)
        // * filtered sorted paged results: https://localhost:44391/api/vehicleMakes/get?filter=(string)&sortby=(string)&currentPage=(int)&objectsPerPage=(int)

        [HttpGet("/api/vehicleMakes/get")]
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
        [HttpPost("/api/vehicleMakes/insert")]
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
        [HttpPut("/api/vehicleMakes/update/{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleMakeViewModel vehicleMakeViewModel) 
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleMakeToUpdate = _mapper.Map<VehicleMakeViewModel, VehicleMake>(vehicleMakeViewModel);

            var result = await _vehicleMakeService.UpdateAsync(id);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }

        // Delete request
        [HttpDelete("/api/vehicleMakes/delete/{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }
    }
}
