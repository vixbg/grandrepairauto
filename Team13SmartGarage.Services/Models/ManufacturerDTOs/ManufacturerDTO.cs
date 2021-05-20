using Team13SmartGarage.Services.Models.Abstract;

namespace Team13SmartGarage.Services.Models.ManufacturerDTOs
{
    public class ManufacturerDTO : DTO<int>
    {
        public string Name { get; set; }
    }
}