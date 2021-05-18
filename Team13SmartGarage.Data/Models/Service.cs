using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Service : Entity<int>
    {
        public VehicleTypes VehicleType { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Service name Must be between 5 and 100 characters.")]
        public string Name { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double FixedPrice { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double PricePerHour { get; set; }
        [Range(0, Double.MaxValue, ErrorMessage = "Time cannot be negative.")]
        public double WorkHours { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}
