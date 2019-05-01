using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Contexts;
using VehicleWebApp.Service.Models;
using VehicleWebApp.Service.Repositories.Common;

namespace VehicleWebApp.Service.Repositories
{
    public class VehicleModelRepository : BaseRepository, IVehicleModelRepository
    {
        public VehicleModelRepository(AppDbContext context) : base(context) { } 

        // Get all vehicle models
        public async Task<IEnumerable<VehicleModel>> ListAsync()
        {
           return await _context.VehicleModels.Include(model => model.Make).ToListAsync();
        }

        // Add new vehicle model
        public async Task AddAsync(VehicleModel vehicleModel)
        {
            await _context.VehicleModels.AddAsync(vehicleModel);
        }

        // Find by Id 
        public async Task<VehicleModel> FindById(Guid Id)
        {
            return await _context.VehicleModels.FindAsync(Id);
        }

        // Update
        public void Update(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
        }

        // Delete
        public void Remove(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Remove(vehicleModel);
        }
    }
}
