using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Services.Common
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListAsync();
        Task<VehicleModelResponse> InsertAsync(VehicleModel vehicleModel);
        Task<VehicleModelResponse> UpdateAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleModelResponse> DeleteAsync(Guid id);
    }
}
