using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewmodels;
using VehicleWebApp.MVC.ViewModels.VehicleMakeViewModels;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.APIErrors;
using VehicleWebApp.Service.Services;

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

        // Get request - all vehicle makes
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAsync();

            var viewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

            return Ok(viewModel);
        }

        // Get request - paged result
        [HttpGet("/api/vehicleMakes/paged/pageNo={currentPage}&pageSize={objectsPerPage}&sortBy={sortOrder}")]
        public async Task<IActionResult> GetPaginatedListAsync(int currentPage, int objectsPerPage, string sortOrder)
        {
            var paginationViewModel = new VehicleMakePaginationViewModel { CurrentPage = currentPage, ObjectsPerPage = objectsPerPage, SortOrder = sortOrder };

            var paginationModel = _mapper.Map<VehicleMakePaginationViewModel, PaginationModel>(paginationViewModel);

            var vehicleMakes = await _vehicleMakeService.PaginatedListAsync(paginationModel);

            var viewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);
            
            return Ok(viewModel);
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
