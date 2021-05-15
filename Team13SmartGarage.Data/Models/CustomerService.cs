using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class CustomerService
    {
        public int CustomerServiceID { get; set; }
        public int ServiceId { get; set; }
        public Services Service { get; set; }
        public int OrderID { get; set; }
        public Orders Order { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
        public bool IsDeleted { get; set; }
    }
}
