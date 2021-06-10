using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.UserDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderCreateWithCustomerServicesDTO : IDTO
    {
        public OrderStatuses Status { get; set; } = OrderStatuses.New;

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public DateTime Date { get; set; } = DateTime.Today;

        public int VehicleId { get; set; }

        public VehicleDTO Vehicle { get; set; }

        public virtual List<CustomerServiceDTO> CustomerServices { get; set; } = new List<CustomerServiceDTO>();

        public double TotalPrice { get; set; } 
    }
}
