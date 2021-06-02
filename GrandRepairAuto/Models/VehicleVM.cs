using System.ComponentModel.DataAnnotations;
using GrandRepairAuto.Data.Enums;

namespace GrandRepairAuto.Web.Models
{
    public class VehicleVM
    {
        [Required]
        public string RegPlate { get; set; }

        public int VehicleModelId { get; set; }

        [Required]
        public string Vin { get; set; }

        public VehicleTypes VehicleType { get; set; }

        public EngineTypes EngineType { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int OwnerId { get; set; }

    }
}
