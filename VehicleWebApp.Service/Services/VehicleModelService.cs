using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories.Common;
using VehicleWebApp.Service.Services.Common;

namespace VehicleWebApp.Service.Services
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

        public async Task<VehicleModelResponse> InsertAsync(VehicleModel vehicleModel)
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

        public async Task<VehicleModelResponse> UpdateAsync(Guid id, VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = await _vehicleModelRepository.FindById(id);

            if (vehicleModelToUpdate == null) return new VehicleModelResponse("Non-existing vehicle model, please check the Id");


            if (string.IsNullOrEmpty(vehicleModel.Name))
            {
                vehicleModelToUpdate.Name = vehicleModelToUpdate.Name;
            }
            else
            {
                vehicleModelToUpdate.Name = vehicleModel.Name;
            }


            if (string.IsNullOrEmpty(vehicleModel.Abbreviation))
            {
                vehicleModelToUpdate.Abbreviation = vehicleModelToUpdate.Abbreviation;
            }
            else
            {
                vehicleModelToUpdate.Abbreviation = vehicleModel.Abbreviation;
            }

            try
            {
                _vehicleModelRepository.Update(vehicleModelToUpdate);

                await _unitOfWork.CompleteAsync();

                return new VehicleModelResponse(vehicleModelToUpdate);
            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message);
            }
        }

        public async Task<VehicleModelResponse> DeleteAsync(Guid id)
        {
            var vehicleModelToDelete = await _vehicleModelRepository.FindById(id);

            if (vehicleModelToDelete == null) return new VehicleModelResponse("Non - existing vehicle model, please check the Id");

            try
            {
                _vehicleModelRepository.Remove(vehicleModelToDelete);

                await _unitOfWork.CompleteAsync();

                return new VehicleModelResponse(vehicleModelToDelete);

            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message);
            }
        }

    }
}
