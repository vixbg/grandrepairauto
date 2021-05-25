﻿using System;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceDTO : DTO<int>
    {
        public int ServiceId { get; set; }
        public int OrderId { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
