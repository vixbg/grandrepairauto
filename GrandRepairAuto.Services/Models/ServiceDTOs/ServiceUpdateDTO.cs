﻿using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.ServiceDTOs
{
    public class ServiceUpdateDTO : IDTO
    {
        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }
    }
}
