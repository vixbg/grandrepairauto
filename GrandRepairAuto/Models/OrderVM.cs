using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GrandRepairAuto.Web.Models
{
    public class OrderVM
    {
        public int Id { get; set; }

        [Required] 
        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public int UserId { get; set; }

        [Required]
        public string UserFullName { get; set; } 

        public int VehicleId { get; set; }

        [Required]
        public string VehicleRegPlate { get; set; } 

        public virtual List<CustomerServiceVM> CustomerServices { get; set; } = new List<CustomerServiceVM>();

        public double TotalPrice { get; set; }
    }
}
