using System.Collections.Generic;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services.Models.Abstract;

namespace Team13SmartGarage.Services.Models.OrderDTOs
{
    public class OrderDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
        public double TotalPrice { get; set; }
    }
}