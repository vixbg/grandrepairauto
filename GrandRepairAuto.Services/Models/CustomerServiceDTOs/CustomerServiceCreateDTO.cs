using System;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Models.Abstract;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceCreateDTO : DTO<int>
    {
        public int ServiceId { get; set; }
        public int OrderID { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
