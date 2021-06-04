using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using System;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderCreateDTO : IDTO
    {
        public OrderStatuses Status { get; set; } = OrderStatuses.New;
        
        public int UserId { get; set; }
        
        public int VehicleId { get; set; }
        
        public DateTime Date { get; set; } = DateTime.Today;
    }
}