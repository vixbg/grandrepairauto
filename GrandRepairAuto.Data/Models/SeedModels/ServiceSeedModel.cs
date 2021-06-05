using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GrandRepairAuto.Data.Enums;

namespace GrandRepairAuto.Data.Models.SeedModels
{
    public class ServiceSeedModel
    {
        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }               

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }

        
    }
}
