﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class CustomerService
    {
        [Key]
        public int CustomerServiceID { get; set; }
        public int ServiceId { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public Services Service { get; set; }
        public int OrderID { get; set; }
        [ForeignKey(nameof(OrderID))]
        public Orders Order { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
        public DateTime IsDeleted { get; set; }
    }
}
