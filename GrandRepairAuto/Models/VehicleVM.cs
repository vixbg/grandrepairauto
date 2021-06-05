using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GrandRepairAuto.Data.Enums;

namespace GrandRepairAuto.Web.Models
{
    public class VehicleVM
    {
        public int Id { get; set; }

        [Required]
        public string RegPlate { get; set; }

        public int VehicleModelId { get; set; }

        public string VehicleModelName { get; set; }

        public string VehicleModelManufacturerName { get;set; }

        [Required]
        public string Vin { get; set; }

        public string VehicleType { get; set; }

        public string EngineType { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int OwnerId { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }

    }
}
