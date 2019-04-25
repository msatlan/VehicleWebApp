using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleWebApp.MVC.ViewModels.VehicleModelViewModels
{
    public class SaveVehicleModelViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [Required]
        public Guid MakeId { get; set; }
    }
}
