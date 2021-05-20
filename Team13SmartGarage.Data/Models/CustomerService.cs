using System;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models.Abstract;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Models
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
