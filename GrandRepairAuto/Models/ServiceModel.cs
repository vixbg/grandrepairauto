using GrandRepairAuto.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrandRepairAuto.Web.Models
{
    public class ServiceModel
    {        
        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }               

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }

    }
}
