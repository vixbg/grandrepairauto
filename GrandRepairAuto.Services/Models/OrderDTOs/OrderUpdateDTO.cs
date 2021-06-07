using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using System;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderUpdateDTO : IDTO
    {
        public OrderStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

    }
}