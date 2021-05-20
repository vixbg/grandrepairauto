using Team13SmartGarage.Data.Enums;
using Team13SmartGarage.Services.Models.Abstract;

namespace Team13SmartGarage.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceUpdateDTO : DTO<int>
    {
        public ServiceStatuses Status { get; set; }
    }
}
