using System;
using System.Collections.Generic;
using System.Text;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Models.CustomerServiceDTOs;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;
using GrandRepairAuto.Services.Models.OrderDTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GrandRepairAuto.Tests.ServiceTests
{
    [TestClass]
    public class ManufacturerServiceTest : GenericServiceTest<ManufacturerService, IManufacturerRepository, Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO, ManufacturerUpdateDTO, GarageContext>
    {
        private ManufacturerCreateDTO _createInput = new ManufacturerCreateDTO()
            {Name = "Opel"};

        private ManufacturerUpdateDTO _updateInput = new ManufacturerUpdateDTO()
            {Name = "Mercedes"};
        public override ManufacturerCreateDTO CreateInput => _createInput;

        public override ManufacturerUpdateDTO UpdateInput => _updateInput;
    }
}
