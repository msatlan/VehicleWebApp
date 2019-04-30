using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApp.Service.Models.Common
{
    public class PagingModel
    {
        public int? CurrentPage { get; set; }

        public int? ObjectsPerPage { get; set; }
    }
}
