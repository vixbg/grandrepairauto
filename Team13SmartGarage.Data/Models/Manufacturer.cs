using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Team13SmartGarage.Data.Models
{
    public class Manufacturer : Entity<int>, ISoftDeletable
    {

        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Manufacturer name should be between 1 and 30 characters.")]
        public string Name { get; set; }

        public List<VehicleModel> VehicleModels { get; set; } = new List<VehicleModel>();
        public DateTime? IsDeleted { get; set; }

    }
}
