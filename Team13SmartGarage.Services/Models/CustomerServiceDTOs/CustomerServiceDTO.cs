using System;
using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceDTO : DTO<int>
    {
        public int ServiceId { get; set; }
        public ServiceStatuses Status { get; set; }
        public DateTime Date { get; set; }
    }
}
