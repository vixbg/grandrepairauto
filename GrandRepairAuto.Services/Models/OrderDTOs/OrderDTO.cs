using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Abstract;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        //TODO: How to stop cascade when displaying services?
        public List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();

        public double TotalPrice { get; set; }
    }
}