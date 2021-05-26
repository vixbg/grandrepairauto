using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.VehicleModelDTOs
{
    public class VehicleModelCreateDTO : IDTO
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
