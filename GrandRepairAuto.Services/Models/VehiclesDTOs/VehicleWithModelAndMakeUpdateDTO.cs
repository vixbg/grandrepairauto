using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.VehiclesDTOs
{
    public class VehicleWithModelAndMakeUpdateDTO : IDTO
    {
        public string RegPlate { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public int OwnerId { get; set; }
    }
}
