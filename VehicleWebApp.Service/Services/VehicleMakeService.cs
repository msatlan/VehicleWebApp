using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;
using VehicleWebApp.Service.Repositories.Common;
using VehicleWebApp.Service.Services.Common;

namespace VehicleWebApp.Service.Services
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
        public async Task<PagedList<VehicleMake>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            // Throw exception when model is not null but values are off? i.e. sortingModel.SortOrder = bla, number of page or objects per page beyond index
            return await _vehicleMakeRepository.ListAsync(pagingModel, sortingModel, filteringModel);
        }
  
        // Save 
        public async Task<VehicleMakeResponse> InsertAsync(VehicleMake vehicleMake)
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
        public async Task<VehicleMakeResponse> UpdateAsync(Guid id)
        {
            var vehicleMakeToUpdate = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMakeToUpdate == null) return new VehicleMakeResponse("Non-existing vehicle make, please check the Id");

            /*
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
            */
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

            if (vehicleMakeToDelete == null) return new VehicleMakeResponse("Non-existing vehicle make, please check the Id");

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
