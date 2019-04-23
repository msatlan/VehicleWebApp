using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // Constructor
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository, IUnitOfWork unitOfWork)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _unitOfWork = unitOfWork;
        }

        // Get all
        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _vehicleMakeRepository.ListAsync();
        }

        // Save 
        public async Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake)
        {
            try
            {
                await _vehicleMakeRepository.AddAsync(vehicleMake);
                await _unitOfWork.CompleteAsync();

                return new VehicleMakeResponse(vehicleMake);
            }
            catch (Exception ex)
            {
                return new VehicleMakeResponse(ex.Message);

            }
        }

        // Update
        public async Task<VehicleMakeResponse> UpdateAsync(Guid id, VehicleMake vehicleMake)
        {
            var vehicleMakeToUpdate = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMakeToUpdate == null) return new VehicleMakeResponse("Non-existing vehicle make");

            // Update properties
            // name
            if (!string.IsNullOrEmpty(vehicleMake.Name))
            {
                vehicleMakeToUpdate.Name = vehicleMake.Name;
            }
            else
            {
                vehicleMakeToUpdate.Name = vehicleMakeToUpdate.Name;
            }
            
            // abbreviation
            if (!string.IsNullOrEmpty(vehicleMake.Abbreviation))
            {
                vehicleMakeToUpdate.Abbreviation = vehicleMake.Abbreviation;
            }
            else
            {
                vehicleMakeToUpdate.Abbreviation = vehicleMakeToUpdate.Abbreviation;
            }

            try
            {
                _vehicleMakeRepository.Update(vehicleMakeToUpdate);
                await _unitOfWork.CompleteAsync();

                return new VehicleMakeResponse(vehicleMakeToUpdate);
            }
            catch (Exception exception)
            {
                //if (exception.InnerException != null) return new SaveVehicleMakeResponse(exception.InnerException.ToString());

                return new VehicleMakeResponse(exception.Message);
            }
        }

        // Delete
        public async Task<VehicleMakeResponse> DeleteAsync(Guid id)
        {
            var vehicleMakeToDelete = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMakeToDelete == null) return new VehicleMakeResponse("Non-existing vehicle make");

            try
            {
                _vehicleMakeRepository.Remove(vehicleMakeToDelete);
                await _unitOfWork.CompleteAsync();

                return new VehicleMakeResponse(vehicleMakeToDelete);
            }
            catch (Exception exception)
            {
                return new VehicleMakeResponse(exception.Message);
            }
        }
    }
}
