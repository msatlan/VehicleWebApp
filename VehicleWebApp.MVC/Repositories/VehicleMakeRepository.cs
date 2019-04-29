using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Contexts;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories;

namespace VehicleWebApp.MVC.Repositories
{
    public class VehicleMakeRepository : BaseRepository, IVehicleMakeRepository 
    {
        // Constructor - calls base class constructor with context parameter
        public VehicleMakeRepository(AppDbContext context) : base(context) { }

        // Get VehicleMakes from database
        public async Task<IEnumerable<VehicleMake>> ListAsync()
        {
            return await _context.VehicleMakes.ToListAsync();
        }

        // Get query results list
        public async Task<IEnumerable<VehicleMake>> QueriedListAsync(VehicleQueryModel queryModel)
        {
            var vehicleMakes = from makes in _context.VehicleMakes select makes;

            Debug.WriteLine(queryModel.SearchString);

            if (!string.IsNullOrEmpty(queryModel.SearchString) || queryModel.SearchString != """")
            {
                vehicleMakes = vehicleMakes.Where(vehicleMake => vehicleMake.Name.Contains(queryModel.SearchString)
                                                 || vehicleMake.Abbreviation.Contains(queryModel.SearchString));
            }

            if (string.IsNullOrEmpty(queryModel.SortOrder)) vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Name);

            switch (queryModel.SortOrder)
            {
                case "NameDesc":
                    vehicleMakes = vehicleMakes.OrderByDescending(vehicleMake => vehicleMake.Name);
                    break;

                case "Abrv":
                    vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Abbreviation);
                    break;

                case "AbrvDesc":
                    vehicleMakes = vehicleMakes.OrderByDescending(vehicleMake => vehicleMake.Abbreviation);
                    break;

                default:
                    vehicleMakes = vehicleMakes.OrderBy(vehicleMake => vehicleMake.Name);
                    break;
            }
            
            int page;
            int objectsPerPage;

            if (queryModel.CurrentPage.HasValue && queryModel.ObjectsPerPage.HasValue)
            {
                page = queryModel.CurrentPage.Value;
                objectsPerPage = queryModel.ObjectsPerPage.Value;
            }
            else
            {
                page = 1;
                objectsPerPage = vehicleMakes.Count();
            };
            
            return await vehicleMakes.Skip((page - 1) * objectsPerPage)
                                     .Take(objectsPerPage)
                                     .ToListAsync();

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
