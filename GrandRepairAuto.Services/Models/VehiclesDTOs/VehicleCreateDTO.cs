using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.VehiclesDTOs
{
    public class VehicleCreateDTO : IDTO
    {
        public string RegPlate { get; set; }
        public int VehicleModelId { get; set; }
        public string Vin { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public EngineTypes EngineType { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int OwnerId { get; set; }
    }
}