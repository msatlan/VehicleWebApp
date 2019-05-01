using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using VehicleWebApp.Service.Models;

namespace VehicleWebApp.MVC.ViewModels
{
    public class VehicleMakeViewModel
    {
        public Guid Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public List<string> Models { get; set; }
    }
}
