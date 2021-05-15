using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Services
    {
        public int ServiceID { get; set; }
        public VehicleTypes VehicleType { get; set; }
        public string Name { get; set; }
        public double FixedPrice { get; set; }
        public double PricePerHour { get; set; }
        public double WorkHours { get; set; }
        public bool IsDeleted { get; set; }
    }
}
