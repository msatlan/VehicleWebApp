using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories;
using VehicleWebApp.Service.Services;

namespace VehicleWebApp.MVC.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
        }

        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _vehicleMakeRepository.ListAsync();
        }
    }
}
