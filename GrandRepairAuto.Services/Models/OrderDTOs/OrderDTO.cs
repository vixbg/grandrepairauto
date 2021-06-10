using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;
using System;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public double TotalPrice { get; set; }
    }
}