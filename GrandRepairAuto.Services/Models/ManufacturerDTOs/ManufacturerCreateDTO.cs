using GrandRepairAuto.Services.Models.Abstract;
using GrandRepairAuto.Services.Models.Contracts;

namespace GrandRepairAuto.Services.Models.ManufacturerDTOs
{
    public class ManufacturerCreateDTO : IDTO
    {
        public string Name { get; set; }
    }
}