using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels.Model;
using VehicleWebApp.Service.Models;
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
    }
}
