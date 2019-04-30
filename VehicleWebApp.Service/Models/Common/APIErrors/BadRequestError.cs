using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VehicleWebApp.Service.Models.Common.APIErrors
{
    public class BadRequestError : APIError
    {
        public BadRequestError(string message) : base((int)HttpStatusCode.BadRequest, HttpStatusCode.BadRequest.ToString(), message) { }
    }
}
