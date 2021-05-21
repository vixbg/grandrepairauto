using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Models.Contracts;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;

namespace GrandRepairAuto.Services
{
    public class ManufacturerService : GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerDTO, ManufacturerDTO>, IManufacturerService
    {
        public ManufacturerService(GenericRepository<Manufacturer, int> repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
