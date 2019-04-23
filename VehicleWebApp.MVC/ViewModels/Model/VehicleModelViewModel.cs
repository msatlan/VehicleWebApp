using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.MVC.ViewModels.Model
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public VehicleMake Make { get; set; }
    }
}
