using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleWebApp.Service.Models
{
    public class VehicleMake
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public List<VehicleModel> Models { get; set; } //= new List<VehicleModel>();
    }
}
