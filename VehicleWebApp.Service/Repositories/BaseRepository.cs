using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApp.Service.Contexts;

namespace VehicleWebApp.Service.Repositories
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
        }
    }
}
