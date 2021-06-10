using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IOrderWithCustomerServicesService : IGenericService<Order, int, OrderWithCustomerServicesDTO, OrderCreateWithCustomerServicesDTO, OrderUpdateWithCustomerServicesDTO>
    {
    }
}
