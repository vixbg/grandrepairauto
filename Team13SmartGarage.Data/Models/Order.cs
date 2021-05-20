using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models.Abstract;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models
{
    public class Order : Entity<int>, ISoftDeletable
    {
        [Required]
        public OrderStatuses Status { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; }

        public virtual List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();

        public double TotalPrice { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
