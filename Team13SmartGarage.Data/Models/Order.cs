using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Order : Entity<int>
    {
        [Required]
        public OrderStatuses Status { get; set; }
        public int UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int VehicleId { get; set; }
        [ForeignKey(nameof(VehicleId))]
        public Vehicle Vehicle { get; set; }
        public List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
        public double TotalPrice { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}
