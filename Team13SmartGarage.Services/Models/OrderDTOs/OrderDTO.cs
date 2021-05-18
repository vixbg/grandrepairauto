using System.Collections.Generic;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.OrderDTOs
{
    public class OrderDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }
        public User User { get; set; }
        public Vehicle Vehicle { get; set; }
        public List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
        public double TotalPrice { get; set; }
    }
}