using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Services.Models.ServiceDTOs
{
    public class ServiceUpdateDTO : DTO<int>
    {
        public VehicleTypes VehicleType { get; set; }
        public string Name { get; set; }
        public double FixedPrice { get; set; }
        public double PricePerHour { get; set; }
        public double WorkHours { get; set; }
    }
}
