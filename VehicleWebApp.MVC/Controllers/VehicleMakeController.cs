using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Services;

namespace VehicleWebApp.MVC.Controllers
{
    [Route("/api/vehicleMakes")]
    public class VehicleMakeController : Controller
    {
        // Added with dependency injection 
        private readonly IVehicleMakeService _vehicleMakeService;

        // Constructor
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        // Handling get request - all vehicle makes
        [HttpGet]
        public async Task<IEnumerable<VehicleMake>> GetAllAsync()
        {
            var vehicleMakes = await _vehicleMakeService.ListAsync();

            return vehicleMakes;
        }
    }
}
