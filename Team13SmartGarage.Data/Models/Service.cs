using System;
using System.ComponentModel.DataAnnotations;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models.Abstract;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models
{
    public class Service : Entity<int>, ISoftDeletable
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

        public DateTime? DeletedOn { get; set; }
    }
}
