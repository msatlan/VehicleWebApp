using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels;
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

        // Handling get request - all vehicle makes
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAsync();

            var viewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

            return Ok(viewModel);
        }

        // Post request
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleMakeViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));
            
            var vehicleMake = _mapper.Map<SaveVehicleMakeViewModel, VehicleMake>(viewModel);

            var result = await _vehicleMakeService.SaveAsync(vehicleMake);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var saveVehicleMakeViewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(saveVehicleMakeViewModel);
        }
        
        // Put request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleMakeViewModel viewModel) 
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleMakeToUpdate = _mapper.Map<VehicleMakeViewModel, VehicleMake>(viewModel);

            var result = await _vehicleMakeService.UpdateAsync(id, vehicleMakeToUpdate);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var updatedVehicleMakeViewModel = _mapper.Map<VehicleMake, VehicleMakeViewModel>(result.VehicleMake);

            return Ok(updatedVehicleMakeViewModel);
        }
    }
}
