using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Services.Models.Abstract;

namespace Team13SmartGarage.Services.Models.ServiceDTOs
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
