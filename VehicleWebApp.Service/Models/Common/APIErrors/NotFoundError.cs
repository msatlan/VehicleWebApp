using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace VehicleWebApp.Service.Models.Common.APIErrors
{
    public class NotFoundError : APIError
    {
        public NotFoundError(string message) : base((int)HttpStatusCode.NotFound, HttpStatusCode.NotFound.ToString(), message) { }
    }
}
