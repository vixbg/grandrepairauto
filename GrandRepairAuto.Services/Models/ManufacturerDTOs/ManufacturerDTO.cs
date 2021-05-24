using GrandRepairAuto.Services.Abstract;

namespace GrandRepairAuto.Services.Models.ManufacturerDTOs
{
    public class ManufacturerDTO : DTO<int>
    {
        public string Name { get; set; }
    }
}