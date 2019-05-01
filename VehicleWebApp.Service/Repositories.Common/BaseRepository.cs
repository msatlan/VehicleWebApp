using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VehicleWebApp.Service.Contexts;

namespace VehicleWebApp.Service.Repositories.Common
{
    // Repository classes will inherit this class as base class and get an instance of AppDbContext
    public abstract class BaseRepository
    {
        // Properties - get through dependency injection
        protected readonly AppDbContext _context;

        // Constructor
        public BaseRepository(AppDbContext context)
        {
            _context = context;

            // load related entities
            _context.VehicleMakes.Include(vehicle => vehicle.Models).ToList();
        }
    }
}
