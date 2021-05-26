﻿using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.VehicleModelDTOs
{
    public class VehicleModelDTO : DTO<int>
    {
        public string Name { get; set; }
        public int ManufacturerId { get; set; }
    }
}
