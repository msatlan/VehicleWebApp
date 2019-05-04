using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Communication
{
    public enum ErrorType
    {
        Null,
        BadRequest,
        NotFound,
        Other
    }

    public class VehicleMakeResponse
    {
        // Properties
        public bool Success { get; set; }

        public string Message { get; set; }

        public VehicleMake VehicleMake { get; set; }

        public ErrorType ErrorType { get; set; }

        // Private constructor - called by other constructors
        private VehicleMakeResponse(bool success, string message, VehicleMake vehicleMake, ErrorType errorType)
        {
            Success = success;
            Message = message;
            VehicleMake = vehicleMake;
            ErrorType = errorType;
        }

        // Constructor for case when request fails - get an error message
        public VehicleMakeResponse(string message, ErrorType errorType) : this(false, message, null, errorType) { }

        // Constructor for case when save is successful
        public VehicleMakeResponse(VehicleMake vehicleMake) : this(true, string.Empty, vehicleMake, ErrorType.Null) { }
    }
}
