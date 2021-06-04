using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Services.Models.OrderDTOs;
using System.Collections.Generic;

namespace GrandRepairAuto.Services.Contracts
{
    public interface IOrderService : IGenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO>
    {
    }
}
