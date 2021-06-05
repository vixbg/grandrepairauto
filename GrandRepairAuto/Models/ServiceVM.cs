using GrandRepairAuto.Data.Enums;

namespace GrandRepairAuto.Web.Models
{
    public class ServiceVM
    {
        public int Id { get; set; }

        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }

        public double TotalPrice { get; set; }

    }
}
