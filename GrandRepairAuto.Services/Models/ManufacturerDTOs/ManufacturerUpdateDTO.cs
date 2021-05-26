using GrandRepairAuto.Services.Abstract;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services.Models.ManufacturerDTOs
{
    public class ManufacturerUpdateDTO : IDTO
    {
        public string Name { get; set; }
    }
}