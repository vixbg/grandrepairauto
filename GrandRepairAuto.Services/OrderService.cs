using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services
{
    public class OrderService : GenericService<Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO>, IOrderService
    {
        public OrderService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
