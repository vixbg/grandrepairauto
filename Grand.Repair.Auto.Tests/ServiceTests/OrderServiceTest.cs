using System;
using System.Collections.Generic;
using System.Text;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.OrderDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class OrderServiceTest : GenericServiceTest<OrderService, IOrderRepository, Order, int, OrderDTO, OrderCreateDTO, OrderUpdateDTO, GarageContext>
    {
        private OrderCreateDTO _createInput = new OrderCreateDTO()
            {Date = DateTime.Now, Status = OrderStatuses.New, UserId = 1, VehicleId = 1};

        private OrderUpdateDTO _updateInput = new OrderUpdateDTO()
            {Status = OrderStatuses.Closed};
        public override OrderCreateDTO CreateInput => _createInput;

        public override OrderUpdateDTO UpdateInput => _updateInput;
    }
}
