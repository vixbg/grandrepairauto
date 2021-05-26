using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.ManufacturerDTOs
{
    public class ManufacturerCreateDTO : IDTO
    {
        public string Name { get; set; }
    }
}