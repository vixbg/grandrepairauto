using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.UserDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using System;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderWithCustomerServicesDTO : DTO<int>, IDTO
    {
        public OrderStatuses Status { get; set; }

        public int UserId { get; set; }

        public UserDTO User { get; set; }

        public DateTime Date { get; set; }

        public int VehicleId { get; set; }

        public VehicleDTO Vehicle { get; set; }

        public virtual List<CustomerServiceDTO> CustomerServices { get; set; }

        public double TotalPrice { get; set; }
    }
}
