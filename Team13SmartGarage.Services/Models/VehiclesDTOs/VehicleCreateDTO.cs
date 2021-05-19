using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.VehiclesDTOs
{
    public class VehicleCreateDTO : DTO<int>
    {
        public string RegPlate { get; set; }
        public int ManufacturerId { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public EngineTypes EngineType { get; set; }
        public string Vin { get; set; }
        public VehicleModel Model { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public User Owner { get; set; }
    }
}