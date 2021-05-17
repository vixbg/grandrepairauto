using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
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
        public DateTime IsDeleted { get; set; }
    }
}
