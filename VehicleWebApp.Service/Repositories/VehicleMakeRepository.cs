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
    public class VehicleMakeRepository : BaseRepository, IVehicleMakeRepository 
    {
        // Constructor - calls base class constructor with context parameter
        public VehicleMakeRepository(AppDbContext context) : base(context) { }

        // Get VehicleMakes from database
        public async Task<PagedList<VehicleMake>> ListAsync(PagingModel pagingModel, SortingModel sortingModel, FilteringModel filteringModel)
        {
            //IQueryable
            var vehicleMakes = from vehicle in _context.VehicleMakes select vehicle;

            // Filtering
            if (filteringModel.SearchString != null)
            {
                vehicleMakes = vehicleMakes.Where(vehicleMake => vehicleMake.Name.Contains(filteringModel.SearchString)
                                                                 || vehicleMake.Abbreviation.Contains(filteringModel.SearchString));
            }

            // Sorting
            if (string.IsNullOrEmpty(sortingModel.SortOrder))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Id);
            }
            else if (sortingModel.SortOrder.Equals("Name", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Name);
            }
            else if (sortingModel.SortOrder.Equals("NameDesc", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderByDescending(vehicleMake => vehicleMake.Name);
            }
            else if (sortingModel.SortOrder.Equals("Abrv", StringComparison.OrdinalIgnoreCase))
            {
                vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Abbreviation);
            }
            else if (sortingModel.SortOrder.Equals("AbrvDesc", StringComparison.OrdinalIgnoreCase))
            {
                 vehicleMakes = vehicleMakes.OrderByDescending(vehicleMake => vehicleMake.Abbreviation);
            } 
            
            // Paging
            return await PagedList<VehicleMake>.CreateAsync(vehicleMakes.AsNoTracking(), 
                                                            pagingModel.CurrentPage ?? 1, 
                                                            pagingModel.ObjectsPerPage ?? _context.VehicleMakes.Count());
        }

        // Save vehicle make to database
        public async Task AddAsync(VehicleMake vehicleMake)
        {
            await _context.VehicleMakes.AddAsync(vehicleMake);
        }

        // Find vehicle make by id 
        public async Task<VehicleMake> FindByIdAsync(Guid id)
        {
            return await _context.VehicleMakes.FindAsync(id);
        }

        // Update vehicle make
        public void Update(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Update(vehicleMake);
        }

        public void Remove(VehicleMake vehicleMake)
        {
            _context.VehicleMakes.Remove(vehicleMake);
        }

        
    }
}
