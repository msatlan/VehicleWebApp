using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;

namespace VehicleWebApp.Service.Repositories.Common
{
    public interface IVehicleMakeRepository
    {
        Task<PagedList<VehicleMake>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task AddAsync(VehicleMake vehicleMake);
        Task<VehicleMake> FindByIdAsync(Guid? id);
        void Update(VehicleMake vehicleMake);
        void Remove(VehicleMake vehicleMake);
    }
}
