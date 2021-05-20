using System;
using System.Collections.Generic;

namespace Team13SmartGarage.Services.Models.ManufacturerDTOs
{
    public class ManufacturerDTO : DTO<int>
    {
        public string Name { get; set; }
    }
}