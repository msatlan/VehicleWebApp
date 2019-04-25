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
    public class VehicleModelService : IVehicleModelService
    {
        // required to check if related vehicle make exists
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IUnitOfWork _unitOfWork;


        public VehicleModelService(IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository, IUnitOfWork unitOfWork)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<VehicleModel>> ListAsync()
        {
            return await _vehicleModelRepository.ListAsync();
        }

        public async Task<VehicleModelResponse> SaveAsync(VehicleModel vehicleModel)
        {
            try
            {
                // check if related vehicle make exists
                var relatedVehicleMake = await _vehicleMakeRepository.FindByIdAsync(vehicleModel.MakeId);

                if (relatedVehicleMake == null) return new VehicleModelResponse("Invalid Vehicle Make");

                // try to save vehicle model if vehicle make exists
                await _vehicleModelRepository.AddAsync(vehicleModel);

                await _unitOfWork.CompleteAsync();

                return new VehicleModelResponse(vehicleModel);

            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message);   
            }
        }
    }
}
