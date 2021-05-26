using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.VehicleModelDTOs
{
    public class VehicleModelUpdateDTO : IDTO
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
