using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
