using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.OrderDTOs;

namespace GrandRepairAuto.Services
{
    public class OrderWithCustomerServicesService : GenericService<Order, int, OrderWithCustomerServicesDTO, OrderCreateWithCustomerServicesDTO, OrderUpdateWithCustomerServicesDTO>, IOrderWithCustomerServicesService
    {
        public OrderWithCustomerServicesService(IOrderRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }

        

    }
}
