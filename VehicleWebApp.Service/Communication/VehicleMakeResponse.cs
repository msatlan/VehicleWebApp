using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Communication
{
    public class VehicleMakeResponse
    {
        // Properties
        public bool Success { get; set; }

        public string Message { get; set; }

        public VehicleMake VehicleMake { get; set; }
        
        // Private constructor - called by other constructors
        private VehicleMakeResponse(bool success, string message, VehicleMake vehicleMake)
        {
            Success = success;
            Message = message;
            VehicleMake = vehicleMake;
        }

        // Constructor for case when request fails - get an error message
        public VehicleMakeResponse(string message) : this(false, message, null) { }

        // Constructor for case when save is successful
        public VehicleMakeResponse(VehicleMake vehicleMake) : this(true, string.Empty, vehicleMake) { }
    }
}
