using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Vehicle : Entity<int>, ISoftDeletable
    {
        [Required]
        [StringLength(7, MinimumLength = 4, ErrorMessage = "Registration Plate must be between 4 and 7 characters.")]
        public string RegPlate { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [ForeignKey(nameof(VehicleModelId))]
        public virtual VehicleModel VehicleModel { get; set; }

        [Required]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        public EngineTypes EngineType { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be 17 characters long.")]
        public string Vin { get; set; }

        [Required]
        [Range(0, 2000000, ErrorMessage = "Mileage must be between 0 and 2 000 000 kilometers.")]
        public int Mileage { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Color must be between 3 and 30 characters.")]
        public string Color { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual User Owner { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
