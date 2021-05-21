using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Models.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services
{
    public class OrderService : GenericService<Order, int, OrderDTO, OrderDTO, OrderUpdateDTO>, IOrderService
    {
        public OrderService(GenericRepository<Order, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
