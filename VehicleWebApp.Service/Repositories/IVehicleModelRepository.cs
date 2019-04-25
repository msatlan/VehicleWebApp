using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> ListAsync();
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindById(Guid Id);
        void Update(VehicleModel vehicleModel);
    }
}
