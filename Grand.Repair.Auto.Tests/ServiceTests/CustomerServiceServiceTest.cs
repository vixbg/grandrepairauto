using System;
using System.Collections.Generic;
using System.Text;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class CustomerServiceServiceTest : GenericServiceTest<CustomerServiceService, ICustomerServiceRepository, CustomerService, int, CustomerServiceDTO, CustomerServiceCreateDTO, CustomerServiceUpdateDTO, GarageContext>
    {
        private CustomerServiceCreateDTO _createInput = new CustomerServiceCreateDTO()
            {Date = DateTime.Now, OrderID = 1, ServiceId = 1, Status = ServiceStatuses.InProgress};

        private CustomerServiceUpdateDTO _updateInput = new CustomerServiceUpdateDTO()
            {Status = ServiceStatuses.Done};
        public override CustomerServiceCreateDTO CreateInput => _createInput;

        public override CustomerServiceUpdateDTO UpdateInput => _updateInput;
    }
}
