using System;
using System.Collections.Generic;
using System.Text;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.Service.Communication
{
    public class VehicleModelResponse
    {
        public bool Success { get; set; }

        public string Message { get; set; }

        public VehicleModel VehicleModel { get; set; }

        public ErrorType ErrorType { get; set; }


        private VehicleModelResponse(bool success, string message, VehicleModel vehicleModel, ErrorType errorType)
        {
            Success = success;
            Message = message;
            VehicleModel = vehicleModel;
            ErrorType = errorType;
        } 

        public VehicleModelResponse(string message, ErrorType errorType) : this(false, message, null, errorType) { }

        public VehicleModelResponse(VehicleModel vehicleModel) : this(true, string.Empty, vehicleModel, ErrorType.Null) { }
    }
}
