using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories;
using VehicleWebApp.Service.Services;

namespace VehicleWebApp.MVC.Services
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IUnitOfWork unitOfWork)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _vehicleMakeRepository.ListAsync();
        }

        public async Task<SaveVehicleMakeResponse> SaveAsync(VehicleMake vehicleMake)
        {
            try
            {
                await _vehicleMakeRepository.AddAsync(vehicleMake);
                await _unitOfWork.CompleteAsync();

                return new SaveVehicleMakeResponse(vehicleMake);
            }
            catch (Exception ex)
            {
                return new SaveVehicleMakeResponse(ex.Message);

            }
        }
    }
}
