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
        Task<SaveVehicleMakeResponse> SaveAsync(VehicleMake vehicleMake);
        Task<SaveVehicleMakeResponse> UpdateAsync(Guid id, VehicleMake vehicleMake);
    }
}
