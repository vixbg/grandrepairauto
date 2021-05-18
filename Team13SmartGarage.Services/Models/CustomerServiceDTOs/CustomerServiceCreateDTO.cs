using System;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceCreateDTO : DTO<int>
    {
        public Service Service { get; set; }
        public Order Order { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
