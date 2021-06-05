using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.VehiclesDTOs
{
    public class VehicleWithModelAndMakeDTO : DTO<int>
    {
        public string RegPlate { get; set; }

        public int VehicleModelId { get; set; }

        public string VehicleModelName { get; set; }

        public string VehicleModelManufacturerName { get; set; }

        public VehicleTypes VehicleType { get; set; }

        public EngineTypes EngineType { get; set; }

        public string Vin { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int OwnerId { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }
    }
}
