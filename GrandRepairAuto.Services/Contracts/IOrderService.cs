using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IOrderService : IGenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO>
    {
    }
}
