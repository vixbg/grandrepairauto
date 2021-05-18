using System;

namespace Team13SmartGarage.Services.Models.ManufacturerDTOs
{
    public class ManufacturerUpdateDTO : DTO<int>
    {
        public string Name { get; set; }
    }
}