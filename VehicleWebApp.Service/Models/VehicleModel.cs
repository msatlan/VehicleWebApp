using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VehicleWebApp.Service.Models
{
    public class VehicleModel
    {
        [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required, MaxLength(20)]
        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public VehicleMake Make { get; set; }

        public Guid MakeId { get; set; }

    }
}
