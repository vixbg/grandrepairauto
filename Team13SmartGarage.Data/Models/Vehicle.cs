using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        [Required]
        [StringLength(7, MinimumLength = 4, ErrorMessage = "Registration Plate must be between 4 and 7 characters.")]
        public string RegPlate { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        [Required]
        public VehicleTypes VehicleType { get; set; }
        [Required]
        public EngineTypes EngineType { get; set; }
        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be 17 characters long.")]
        public string Vin { get; set; }
        [Required]
        public int ModelId { get; set; }
        public VehicleModel Model { get; set; }
        [Required]
        [Range(0, 2000000, ErrorMessage = "Mileage must be between 0 and 2 000 000 kilometers.")]
        public int Mileage { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Color must be between 3 and 30 characters.")]
        public string Color { get; set; }
        [Required]
        public int OwnerId { get; set; }
        public User Owner { get; set; }
        public DateTime? IsDeleted { get; set; }


    }
}
