using System.Collections.Generic;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.Abstract;
using Microsoft.VisualBasic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderUpdateDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }

        public DateAndTime Date { get; set; }

        public Vehicle VehicleId { get; set; }

        //TODO: How to update services?
    }
}