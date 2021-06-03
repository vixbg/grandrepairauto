using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Contracts;
using Microsoft.VisualBasic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderUpdateDTO : IDTO
    {
        public OrderStatuses Status { get; set; }

        public DateAndTime Date { get; set; }

        public Vehicle VehicleId { get; set; }

    }
}