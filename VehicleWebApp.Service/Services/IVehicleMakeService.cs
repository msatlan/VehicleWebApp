using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Services
{
    public interface IVehicleMakeService
    {
        Task<IEnumerable<VehicleMake>> ListAsync();
        Task<VehicleMakeResponse> SaveAsync(VehicleMake vehicleMake);
        Task<VehicleMakeResponse> UpdateAsync(Guid id, VehicleMake vehicleMake);
        Task<VehicleMakeResponse> DeleteAsync(Guid id);
    }
}
