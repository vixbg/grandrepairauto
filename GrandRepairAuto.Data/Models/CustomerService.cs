using System;
using System.ComponentModel.DataAnnotations.Schema;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models.Abstract;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Models
{
    public class CustomerService : Entity<int>, ISoftDeletable
    {
        public int ServiceId { get; set; }

        [ForeignKey(nameof(ServiceId))]
        public virtual Service Service { get; set; }

        public int OrderID { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Order Order { get; set; }

        public ServiceStatuses Status { get; set; }

        public DateTime Date { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
