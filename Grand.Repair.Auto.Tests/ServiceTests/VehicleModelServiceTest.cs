using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.VehicleModelDTOs;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class VehicleModelServiceTest : GenericServiceTest<VehicleModelService, IVehicleModelRepository, VehicleModel, int, VehicleModelDTO, VehicleModelCreateDTO, VehicleModelUpdateDTO, GarageContext>
    {
        private VehicleModelCreateDTO _createInput = new VehicleModelCreateDTO()
        { ManufacturerId = 1, Name = "Corsa"};

        private VehicleModelUpdateDTO _updateInput = new VehicleModelUpdateDTO()
        { Name = "Astra"};
        public override VehicleModelCreateDTO CreateInput => _createInput;

        public override VehicleModelUpdateDTO UpdateInput => _updateInput;
    }
}
