using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderWithCustomerServicesDTO : IDTO
    {
        public OrderStatuses Status { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

        public virtual List<CustomerServiceDTO> CustomerServices { get; set; } = new List<CustomerServiceDTO>();

        public double TotalPrice { get; set; }
    }
}
