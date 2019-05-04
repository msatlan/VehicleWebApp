using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;

namespace VehicleWebApp.Service.Repositories.Common
{
    public interface IVehicleModelRepository
    {
        Task<PagedList<VehicleModel>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task AddAsync(VehicleModel vehicleModel);
        Task<VehicleModel> FindById(Guid? Id);
        void Update(VehicleModel vehicleModel);
        void Remove(VehicleModel vehicleModel);
    }
}
