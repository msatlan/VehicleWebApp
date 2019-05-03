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
    public interface IVehicleModelService
    {
        Task<PagedList<VehicleModel>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel);
        Task<VehicleModelResponse> InsertAsync(VehicleModel vehicleModel);
        Task<VehicleModelResponse> UpdateAsync(Guid id, VehicleModel vehicleModel);
        Task<VehicleModelResponse> DeleteAsync(Guid id);
    }
}
