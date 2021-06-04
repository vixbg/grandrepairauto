using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Web.Models
{
    public class OrderVM
    {
        public int Id { get; set; }

        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public string User { get; set; } //fullname/email

        public int VehicleId { get; set; }

        public string Vehicle { get; set; } //reg plate

        public virtual List<CustomerServiceVM> CustomerServices { get; set; } = new List<CustomerServiceVM>();

        public double TotalPrice { get; set; }
    }
}
