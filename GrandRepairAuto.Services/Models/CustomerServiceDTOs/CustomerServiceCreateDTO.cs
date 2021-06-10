using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using System;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceCreateDTO : IDTO
    {
        public int ServiceId { get; set; }

        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }

        public double TotalPrice  => PricePerHour * WorkHours;

        public int OrderID { get; set; }
       
        public ServiceStatuses Status { get; set; }

        public DateTime Date => DateTime.Today;
    }
}
