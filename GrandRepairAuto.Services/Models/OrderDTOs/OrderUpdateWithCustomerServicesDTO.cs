using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderUpdateWithCustomerServicesDTO : IDTO
    {
        public OrderStatuses Status { get; set; } = OrderStatuses.New;

        public int UserId { get; set; }

        public int VehicleId { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        public virtual List<CustomerServiceDTO> CustomerServices { get; set; } = new List<CustomerServiceDTO>();

        public double TotalPrice { get; set; }
    }
}
