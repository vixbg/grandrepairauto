using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models.Abstract;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Models
{
    public class Order : Entity<int>, ISoftDeletable
    {
        [Required]
        public OrderStatuses Status { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

        [ForeignKey(nameof(VehicleId))]
        public virtual Vehicle Vehicle { get; set; }

        public virtual List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();

        public double TotalPrice { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
