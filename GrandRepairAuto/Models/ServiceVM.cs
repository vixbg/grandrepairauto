using GrandRepairAuto.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class ServiceVM
    {
        public int Id { get; set; }

        [Required]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Service name Must be between 5 and 100 characters.")]
        public string Name { get; set; }

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double PricePerHour { get; set; }

        [Required]
        [Range(0, Double.MaxValue, ErrorMessage = "Time cannot be negative.")]
        public double WorkHours { get; set; }

        public string Currency { get; set; }

        public double TotalPrice { get; set; }

    }
}
