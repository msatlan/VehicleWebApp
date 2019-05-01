using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels.Common;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewmodels;
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
        //             * results on 1 page: https://localhost:44391/api/vehicleMakes  
        //                 * paged results: https://localhost:44391/api/vehicleMakes?currentPage=(int)&objectsPerPage=(int)
        //         * sorted results 1 page: https://localhost:44391/api/vehicleMakes?sortOrder=(string)
        //          * sorted paged results: https://localhost:44391/api/vehicleMakes?sortOrder=(string)&currentPage=(int)&objectsPerPage=(int)
        //       * filtered results 1 page: https://localhost:44391/api/vehicleMakes?searchString=(string)
        //        * filtered paged results: https://localhost:44391/api/vehicleMakes?searchString=(string)&currentPage=(int)&objectsPerPage=(int)
        // * filtered sorted paged results: https://localhost:44391/api/vehicleMakes?searchString=(string)&sortOrder=(string)&currentPage=(int)&objectsPerPage=(int)

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] QueryViewModel viewModel)
        {
            var pagingModel = _mapper.Map<QueryViewModel, PagingModel>(viewModel);
            var filteringModel = _mapper.Map<QueryViewModel, FilteringModel>(viewModel);
            var sortingModel = _mapper.Map<QueryViewModel, SortingModel>(viewModel);

            if (string.IsNullOrEmpty(viewModel.SortOrder) && string.IsNullOrEmpty(viewModel.SearchString))
            {
                var vehicleMakes = await _vehicleMakeService.ListAsync(pagingModel, null, null);

                var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

                return Ok(vehicleMakeViewModel);
            }
            else if (string.IsNullOrEmpty(viewModel.SortOrder) && !string.IsNullOrEmpty(viewModel.SearchString))
            {
                var vehicleMakes = await _vehicleMakeService.ListAsync(pagingModel, null, filteringModel);

                var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

                return Ok(vehicleMakeViewModel);
            }
            else if (!string.IsNullOrEmpty(viewModel.SortOrder) && string.IsNullOrEmpty(viewModel.SearchString))
            {
                var vehicleMakes = await _vehicleMakeService.ListAsync(pagingModel, sortingModel, null);

                var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

                return Ok(vehicleMakeViewModel);
            }
            else
            {
                var vehicleMakes = await _vehicleMakeService.ListAsync(pagingModel, sortingModel, filteringModel);

                var vehicleMakeViewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

                return Ok(vehicleMakeViewModel);
            }
    
         }

        // Post request
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleMakeViewModel saveVehicleMakeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));
            
            var vehicleMake = _mapper.Map<SaveVehicleMakeViewModel, VehicleMake>(saveVehicleMakeViewModel);

            var result = await _vehicleMakeService.SaveAsync(vehicleMake);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }
        
        // Put request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleMakeViewModel vehicleMakeViewModel) 
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleMakeToUpdate = _mapper.Map<VehicleMakeViewModel, VehicleMake>(vehicleMakeViewModel);

            var result = await _vehicleMakeService.UpdateAsync(id, vehicleMakeToUpdate);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }

        // Delete request
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleMakeService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(viewModel);
        }
    }
}
