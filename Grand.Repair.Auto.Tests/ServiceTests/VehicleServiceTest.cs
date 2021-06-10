using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.VehiclesDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class VehicleServiceTest : GenericServiceTest<VehicleService, IVehicleRepository, Vehicle, int, VehicleDTO, VehicleCreateDTO, VehicleUpdateDTO, GarageContext>
    {
        private VehicleCreateDTO _createInput = new VehicleCreateDTO()
        { Color = "blue", EngineType = EngineTypes.Electric, Mileage = 200000, OwnerId = 1, RegPlate = "CB0987BP", VehicleModelId = 1, VehicleType = VehicleTypes.Motorcycle, Vin = "WBAHN83528DT86934"};

        private VehicleUpdateDTO _updateInput = new VehicleUpdateDTO()
        { Mileage = 191919};
        public override VehicleCreateDTO CreateInput => _createInput;

        public override VehicleUpdateDTO UpdateInput => _updateInput;
    }
}
