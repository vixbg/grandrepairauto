using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderCreateWithCustomerServicesDTO : IDTO
    {
        public OrderStatuses Status { get; set; } = OrderStatuses.New;

        public int UserId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public int VehicleId { get; set; }

        public virtual List<CustomerServiceCreateDTO> CustomerServices { get; set; } = new List<CustomerServiceCreateDTO>();

        public double TotalPrice { get; set; } 
    }
}
