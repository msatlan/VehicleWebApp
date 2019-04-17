using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Repositories
{
    public interface IVehicleMakeRepository
    {
        Task<IEnumerable<VehicleMake>> ListAsync();
        Task AddAsync(VehicleMake vehicleMake);
    }
}
