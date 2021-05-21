using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Models.Abstract;

namespace GrandRepairAuto.Services.Models.VehiclesDTOs
{
    public class VehicleDTO : DTO<int>
    {
        public string RegPlate { get; set; }
        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public string Vin { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public EngineTypes EngineType { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int OwnerId { get; set; }
    }
}