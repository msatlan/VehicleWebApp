using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VehicleWebApp.Service.Models.Common.APIErrors
{
    public class ModelStateError
    {
        public int StatusCode { get; set; }

        public string StatusDescription { get; set; }

        public List<string> Message { get; set; }


        public ModelStateError(List<string> message)
        {
            StatusCode = (int)HttpStatusCode.BadRequest;
            StatusDescription = HttpStatusCode.BadRequest.ToString();
            Message = message;
        }
    }
}
