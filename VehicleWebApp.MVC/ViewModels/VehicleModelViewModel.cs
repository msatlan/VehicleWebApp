using System;
using System.ComponentModel.DataAnnotations;

namespace VehicleWebApp.MVC.ViewModels
{
    public class VehicleModelViewModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        [Required]
        public Guid MakeId { get; set; }

        public string Make { get; set; }
    }
}
