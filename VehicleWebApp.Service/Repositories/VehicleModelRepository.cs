using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Common;
using VehicleWebApp.Service.Contexts;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Models.Common;
using VehicleWebApp.Service.Repositories.Common;

namespace VehicleWebApp.Service.Repositories
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        private readonly IUnitOfWork _unitOfWork;

        public VehicleModelRepository(AppDbContext context, IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        } 

        // Get vehicle models
        public async Task<PagedList<VehicleModel>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {   
            // IQueryable
            var vehicleModels = from vehicleModel in _context.VehicleModels select vehicleModel;

            // Filtering
            if (filteringModel.Filter != null)
            {
                vehicleModels = vehicleModels.Where(vehicleModel => vehicleModel.Name.Contains(filteringModel.Filter)
                                                                    || vehicleModel.Abbreviation.Contains(filteringModel.Filter)
                                                                    || vehicleModel.Make.Name.Contains(filteringModel.Filter));
            }

            // Sorting
            if (string.IsNullOrEmpty(sortingModel.SortBy))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Id);
            }
            else if (sortingModel.SortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("NameDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.Name);
            }
            else if (sortingModel.SortBy.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Abbreviation);
            }
            else if (sortingModel.SortBy.Equals("AbrvDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.Abbreviation);
            }
            else if (sortingModel.SortBy.Equals("Make", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderBy(vehicleModel => vehicleModel.Make);
            }
            else if (sortingModel.SortBy.Equals("MakeDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleModels = vehicleModels.OrderByDescending(vehicleModel => vehicleModel.Make);
            }

            // Paging
            return await PagedList<VehicleModel>.CreateAsync(vehicleModels,
                                                             pagingModel.CurrentPage ?? 1,
                                                             pagingModel.ObjectsPerPage ?? _context.VehicleModels.Count());
        }

        // Add new vehicle model
        public async Task AddAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
            await _unitOfWork.CompleteAsync();
        }

        // Find by Id 
        public async Task<VehicleModel> FindById(Guid? Id)
        {
            return await _context.VehicleModels.FindAsync(Id);
        }

        // Update
        public async Task Update(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
            await _unitOfWork.CompleteAsync();
        }

        // Delete
        public async Task Remove(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
            await _unitOfWork.CompleteAsync();
        }
    }
}
