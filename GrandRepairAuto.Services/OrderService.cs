using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services
{
    public class OrderService : GenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO>, IOrderService
    {
        public OrderService(GenericRepository<Order, int> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
