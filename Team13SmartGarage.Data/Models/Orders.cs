using System;
using System.Collections.Generic;
using System.Text;
using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Data.Models
{
    public class Orders
    {
        public int OrderID { get; set; }
        public OrderStatuses Status { get; set; }
        public int UserId { get; set; }
        public Users User { get; set; }
        public int VehicleId { get; set; }
        public Vehicles Vehicle { get; set; }
        public List<CustomerService> CustomerServices { get; set; }
        public double TotalPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
