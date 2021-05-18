using Team13SmartGarage.Data.Enums;

namespace Team13SmartGarage.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceUpdateDTO : DTO<int>
    {
        public ServiceStatuses Status { get; set; }
    }
}
