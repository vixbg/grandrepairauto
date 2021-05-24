using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.ServiceDTOs
{
    public class ServiceDTO : DTO<int>
    {
        public VehicleTypes VehicleType { get; set; }
        public string Name { get; set; }
        public double FixedPrice { get; set; }
        public double PricePerHour { get; set; }
        public double WorkHours { get; set; }
    }
}
