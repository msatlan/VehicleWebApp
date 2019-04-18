using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApp.Service.Models.APIErrors
{
    public class APIError
    {
        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public string Message { get; set; }


        public APIError(int statusCode, string statusDescription, string message)
        {
            StatusCode = statusCode;
            StatusDescription = statusDescription;
            Message = message;
        }
    }
}
