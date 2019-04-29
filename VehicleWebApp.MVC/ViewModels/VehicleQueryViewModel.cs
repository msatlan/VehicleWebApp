using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleWebApp.MVC.ViewModels
{
    public class VehicleQueryViewModel
    {
        public string SearchString { get; set; }

        public int CurrentPage { get; set; }

        public int ObjectsPerPage { get; set; }

        public string SortOrder { get; set; }
    }
}
