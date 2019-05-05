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
    public class VehicleModelService : IVehicleModelService
    {
        // required to check if related vehicle make exists
        private readonly IVehicleMakeRepository _vehicleMakeRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleMakeRepository vehicleMakeRepository, IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleMakeRepository = vehicleMakeRepository;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<PagedList<VehicleModel>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            return await _vehicleModelRepository.ListAsync(pagingModel, sortingModel, filteringModel);
        }

        public async Task<VehicleModelResponse> InsertAsync(VehicleModel vehicleModel)
        {
            try
            {
                // check if related vehicle make exists
                var relatedVehicleMake = await _vehicleMakeRepository.FindByIdAsync(vehicleModel.MakeId);

                if (relatedVehicleMake == null) return new VehicleModelResponse("Invalid Vehicle Make", ErrorType.BadRequest);

                // try to save vehicle model if vehicle make exists
                await _vehicleModelRepository.AddAsync(vehicleModel);

                return new VehicleModelResponse(vehicleModel);

            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message, ErrorType.Other);   
            }
        }

        public async Task<VehicleModelResponse> UpdateAsync(Guid id, VehicleModel vehicleModel)
        {
            var vehicleModelToUpdate = await _vehicleModelRepository.FindById(id);

            if (vehicleModelToUpdate == null) return new VehicleModelResponse("Non-existing vehicle model, please check the Id", ErrorType.BadRequest);


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
                await _vehicleModelRepository.Update(vehicleModelToUpdate);

                return new VehicleModelResponse(vehicleModelToUpdate);
            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message, ErrorType.Other);
            }
        }

        public async Task<VehicleModelResponse> DeleteAsync(Guid? id)
        {
            if (id == null) return new VehicleModelResponse("Id is null or of wrong type, please enter a valid Id", ErrorType.BadRequest);

            var vehicleModelToDelete = await _vehicleModelRepository.FindById(id);

            if (vehicleModelToDelete == null) return new VehicleModelResponse("Non-existing vehicle model, please enter a valid Id", ErrorType.NotFound);

            try
            {
                await _vehicleModelRepository.Remove(vehicleModelToDelete);

                return new VehicleModelResponse(vehicleModelToDelete);

            }
            catch (Exception exception)
            {
                return new VehicleModelResponse(exception.Message, ErrorType.Other);
            }
        }

    }
}
