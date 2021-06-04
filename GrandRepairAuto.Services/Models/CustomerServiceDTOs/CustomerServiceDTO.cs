using System;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceDTO : DTO<int>
    {
        public int ServiceId { get; set; }

        public VehicleTypes VehicleType { get; set; }

        public string Name { get; set; }

        public double PricePerHour { get; set; }

        public double WorkHours { get; set; }

        public double TotalPrice { get; set; }
        
        public int OrderId { get; set; }
        
        public ServiceStatuses Status { get; set; }
        
        public DateTime Date { get; set; }
    }
}
