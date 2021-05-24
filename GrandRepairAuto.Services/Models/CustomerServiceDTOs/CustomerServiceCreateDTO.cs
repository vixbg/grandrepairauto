using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Contracts;
using System;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceCreateDTO : IDTO
    {
        //TODO: NOT Working when creating service.
        public int ServiceId { get; set; }
        public int OrderID { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
