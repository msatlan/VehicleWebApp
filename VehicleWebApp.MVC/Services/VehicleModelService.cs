using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories;
using VehicleWebApp.Service.Services;

namespace VehicleWebApp.MVC.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IUnitOfWork _unitOfWork;


        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleModel>> ListAsync()
        {
            return await _vehicleModelRepository.ListAsync();
        }
    }
}
