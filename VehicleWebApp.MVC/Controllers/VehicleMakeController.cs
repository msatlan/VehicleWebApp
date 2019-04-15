using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.MVC.ViewModels;
using VehicleWebApp.Service.Models;
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
        public async Task<IEnumerable<VehicleMakeViewModel>> GetAllAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAsync();

            var viewModel = _mapper.Map<IEnumerable<VehicleMake>, IEnumerable<VehicleMakeViewModel>>(vehicleMakes);

            return viewModel;
        }
    }
}
