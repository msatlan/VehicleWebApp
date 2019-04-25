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


        private VehicleModelResponse(bool success, string message, VehicleModel vehicleModel)
        {
            Success = success;
            Message = message;
            VehicleModel = vehicleModel;
        } 

        public VehicleModelResponse(string message) : this(false, message, null) { }

        public VehicleModelResponse(VehicleModel vehicleModel) : this(true, string.Empty, vehicleModel) { }

    }
}
