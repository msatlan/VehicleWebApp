using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.Extensions;
using VehicleWebApp.MVC.ViewModels.VehicleModelViewModels;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common.APIErrors;
using VehicleWebApp.Service.Services;

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
        public async Task<IActionResult> GetAllAsync()
        {
            var vehicleModels = await _vehicleModelService.ListAsync();

            var viewModel = _mapper.Map<IEnumerable<VehicleModel>, IEnumerable<VehicleModelViewModel>>(vehicleModels);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveVehicleModelViewModel saveVehicleModelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleModelToSave = _mapper.Map<SaveVehicleModelViewModel, VehicleModel>(saveVehicleModelViewModel);

            var result = await _vehicleModelService.SaveAsync(vehicleModelToSave);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] VehicleModelViewModel vehicleModelViewModel)
        {
            if (!ModelState.IsValid) return BadRequest(new ModelStateError(ModelState.GetErrorMessages()));

            var vehicleModelToUpdate = _mapper.Map<VehicleModelViewModel, VehicleModel>(vehicleModelViewModel);

            var result = await _vehicleModelService.UpdateAsync(id, vehicleModelToUpdate);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _vehicleModelService.DeleteAsync(id);

            if (!result.Success) return BadRequest(new BadRequestError(result.Message));

            var viewModel = _mapper.Map<VehicleModel, VehicleModelViewModel>(result.VehicleModel);

            return Ok(viewModel);
        }
    }
}
