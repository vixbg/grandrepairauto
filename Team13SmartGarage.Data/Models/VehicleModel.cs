using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Models.Abstract;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models
{
    public class VehicleModel : Entity<int>, ISoftDeletable
    {
        [Required]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "Model name should be between 1 and 30 characters.")]
        public string Name { get; set; }

        public int ManufacturerId { get; set; }

        [ForeignKey(nameof(ManufacturerId))]
        public virtual Manufacturer Manufacturer { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
