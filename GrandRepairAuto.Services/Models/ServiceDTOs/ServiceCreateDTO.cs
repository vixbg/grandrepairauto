using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Models.Abstract;
using GrandRepairAuto.Services.Models.Contracts;

namespace GrandRepairAuto.Services.Models.ServiceDTOs
{
    public class ServiceCreateDTO : IDTO
    {
        public VehicleTypes VehicleType { get; set; }
        public string Name { get; set; }
        public double FixedPrice { get; set; }
        public double PricePerHour { get; set; }
        public double WorkHours { get; set; }
    }
}
