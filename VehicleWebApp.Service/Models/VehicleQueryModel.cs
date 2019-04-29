using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace VehicleWebApp.Service.Models
{
    public class VehicleQueryModel
    {
        public string SearchString { get; set; }

        public int? CurrentPage { get; set; }
        
        public int? ObjectsPerPage { get; set; }

        public string SortOrder { get; set; }
    }
}
