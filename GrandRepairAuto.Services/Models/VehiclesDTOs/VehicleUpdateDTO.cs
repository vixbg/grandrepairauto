﻿using GrandRepairAuto.Data.Enums;
using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.VehiclesDTOs
{
    public class VehicleUpdateDTO : IDTO
    {
        public string RegPlate { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public int OwnerId { get; set; }
    }
}