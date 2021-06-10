using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models.Abstract;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Models
{
    public class CustomerService : Entity<int>, ISoftDeletable
    {
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }

        public VehicleTypes VehicleType { get; set; }

        [StringLength(100, MinimumLength = 5, ErrorMessage = "Service name Must be between 5 and 100 characters.")]
        public string Name { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double PricePerHour { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Time cannot be negative.")]
        public double WorkHours { get; set; }

        public int OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }

        public ServiceStatuses Status { get; set; }

        [Range(0, Double.MaxValue, ErrorMessage = "Price cannot be negative.")]
        public double TotalPrice { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
