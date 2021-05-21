using System.Collections.Generic;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.Abstract;

namespace GrandRepairAuto.Services.Models.OrderDTOs
{
    public class OrderUpdateDTO : DTO<int>
    {
        public OrderStatuses Status { get; set; }
        public List<CustomerService> CustomerServices { get; set; } = new List<CustomerService>();
        public double TotalPrice { get; set; }
    }
}