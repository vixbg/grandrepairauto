using System;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceDTO : DTO<int>
    {
        public Service Service { get; set; }
        //public Order Order { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
