using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleWebApp.MVC.ViewModels
{
    public class QueryViewModel
    {
        public int? CurrentPage { get; set; } 

        public int? ObjectsPerPage { get; set; }

        public string Filter { get; set; }

        public string SortBy { get; set; }
    }
}
