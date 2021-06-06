using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class VehicleVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Registration Plate must be between 4 and 8 characters.")]
        public string RegPlate { get; set; }

        public int VehicleModelId { get; set; }

        [Required]
        public string VehicleModelName { get; set; }

        [Required]
        public string VehicleModelManufacturerName { get; set; }

        [Required]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "VIN must be 17 characters long.")]
        public string Vin { get; set; }

        [Required]
        public string VehicleType { get; set; }

        [Required]
        public string EngineType { get; set; }

        [Required]
        [Range(0, 2000000, ErrorMessage = "Mileage must be between 0 and 2 000 000 kilometers.")]
        public int Mileage { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Color must be between 3 and 30 characters.")]
        public string Color { get; set; }

        public int OwnerId { get; set; }

        [Required]
        public string OwnerFirstName { get; set; }

        [Required]
        public string OwnerLastName { get; set; }
    }
}
