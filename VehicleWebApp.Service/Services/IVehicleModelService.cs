﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> ListAsync();
    }
}