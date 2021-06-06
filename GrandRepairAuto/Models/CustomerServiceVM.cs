using GrandRepairAuto.Data.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class CustomerServiceVM
    {
        public int ServiceId { get; set; }

        [Required]
        public VehicleTypes VehicleType { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Service name Must be between 5 and 100 characters.")]
        public string Name { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double PricePerHour { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Time cannot be negative.")]
        public double WorkHours { get; set; }

        public ServiceStatuses Status { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double TotalPrice { get => this.PricePerHour * this.WorkHours; }

        public DateTime Date { get; set; }
    }
}
