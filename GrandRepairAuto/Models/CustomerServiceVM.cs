using GrandRepairAuto.Data.Enums;
using System;

namespace GrandRepairAuto.Web.Models
{
    public class CustomerServiceVM
    {
        public int ServiceId { get; set; }

        public int OrderId { get; set; }

        public ServiceStatuses Status { get; set; }

        public DateTime Date { get; set; }
    }
}
