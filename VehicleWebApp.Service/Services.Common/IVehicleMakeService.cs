using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Communication;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;

namespace VehicleWebApp.Service.Services.Common
{
    public interface IVehicleMakeService
    {
        Task<PagedList<VehicleMake>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleMakeResponse> InsertAsync(VehicleMake vehicleMake);
        Task<VehicleMakeResponse> UpdateAsync(Guid? id, VehicleMake vehicleMake);
        Task<VehicleMakeResponse> DeleteAsync(Guid? id);
    }
}
