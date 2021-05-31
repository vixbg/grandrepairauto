using GrandRepairAuto.Data.Enums;
using System;

namespace GrandRepairAuto.Web.Models
{
    public class OrderVM
    {
        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public double TotalPrice { get; set; }
    }
}
