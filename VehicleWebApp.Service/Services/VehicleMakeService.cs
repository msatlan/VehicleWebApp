﻿using System;
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

        // Constructor
        public VehicleMakeService(IVehicleMakeRepository vehicleMakeRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
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

                return new VehicleMakeResponse(vehicleMake);
            }
            catch (Exception exception)
            {
                return new VehicleMakeResponse(exception.Message, ErrorType.Other);
            }
        }

        // Update
        public async Task<VehicleMakeResponse> UpdateAsync(Guid? id, VehicleMake vehicleMake)
        {
            var vehicleMakeToUpdate = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMakeToUpdate == null) return new VehicleMakeResponse("Non-existing vehicle model, please check the Id", ErrorType.BadRequest);

            if (string.IsNullOrEmpty(vehicleMake.Name))
            {
                vehicleMakeToUpdate.Name = vehicleMakeToUpdate.Name;
            }
            else
            {
                vehicleMakeToUpdate.Name = vehicleMake.Name;
            }


            if (string.IsNullOrEmpty(vehicleMake.Abbreviation))
            {
                vehicleMakeToUpdate.Abbreviation = vehicleMakeToUpdate.Abbreviation;
            }
            else
            {
                vehicleMakeToUpdate.Abbreviation = vehicleMake.Abbreviation;
            }

            try
            {
                await _vehicleMakeRepository.Update(vehicleMakeToUpdate);

                return new VehicleMakeResponse(vehicleMakeToUpdate);
            }
            catch (Exception exception)
            {
                return new VehicleMakeResponse(exception.Message, ErrorType.Other);
            }
        }
        
        // Delete
        public async Task<VehicleMakeResponse> DeleteAsync(Guid? id)
        { 
            var vehicleMakeToDelete = await _vehicleMakeRepository.FindByIdAsync(id);

            if (vehicleMakeToDelete == null) return new VehicleMakeResponse("Non-existing vehicle make, please enter a valid Id", ErrorType.NotFound);

            try
            {
                await _vehicleMakeRepository.Remove(vehicleMakeToDelete);

                return new VehicleMakeResponse(vehicleMakeToDelete);
            }
            catch (Exception exception)
            { 
                return new VehicleMakeResponse(exception.Message, ErrorType.Other);
            }
        }
    }
}
