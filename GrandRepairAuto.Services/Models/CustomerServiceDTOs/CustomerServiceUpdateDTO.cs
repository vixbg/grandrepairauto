using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Models.Abstract;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceUpdateDTO : DTO<int>
    {
        public ServiceStatuses Status { get; set; }
    }
}
