using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.ServiceDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class ServiceServiceTest : GenericServiceTest<ServiceService, IServiceRepository, Service, int, ServiceDTO, ServiceCreateDTO, ServiceUpdateDTO, GarageContext>
    {
        private ServiceCreateDTO _createInput = new ServiceCreateDTO()
        { Name = "Oil Change", PricePerHour = 30, VehicleType = VehicleTypes.Car, WorkHours = 1};

        private ServiceUpdateDTO _updateInput = new ServiceUpdateDTO()
        { Name = "Brake Pads Change"};
        public override ServiceCreateDTO CreateInput => _createInput;

        public override ServiceUpdateDTO UpdateInput => _updateInput;
    }
}
