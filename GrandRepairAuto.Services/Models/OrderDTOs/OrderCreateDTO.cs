using System;
using System.Collections.Generic;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.Abstract;
using GrandRepairAuto.Services.Models.Contracts;
using Microsoft.VisualBasic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderCreateDTO : IDTO
    {
        public OrderStatuses Status { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public DateTime Date { get; set; }
        
        //TODO: How to add date ( to now )?
        //TODO: How to add services?
        
    }
}