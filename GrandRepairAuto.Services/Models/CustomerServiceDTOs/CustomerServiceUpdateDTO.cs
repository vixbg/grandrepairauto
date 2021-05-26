using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.CustomerServiceDTOs
{
    public class CustomerServiceUpdateDTO : IDTO
    {
        public ServiceStatuses Status { get; set; }
    }
}
