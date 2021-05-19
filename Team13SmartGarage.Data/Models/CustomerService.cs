using System;
using System.ComponentModel.DataAnnotations.Schema;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class CustomerService : Entity<int>, ISoftDeletable
    {
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Service Service { get; set; }
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Order Order { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime? IsDeleted { get; set; }
    }
}
