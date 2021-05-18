using System;

namespace Team13SmartGarage.Services.Models.ManufacturerDTOs
{
    public class ManufacturerCreateDTO : DTO<int>
    {
        public string Name { get; set; }        
    }
}