using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ManufacturerDTOs;

namespace GrandRepairAuto.Services
{
    public class ManufacturerService : GenericService<Manufacturer, int, ManufacturerDTO, ManufacturerCreateDTO, ManufacturerUpdateDTO>, IManufacturerService
    {
        public ManufacturerService(IManufacturerRepository repository, IMapper mapper) : base(repository, mapper)
        {

        }
    }
}
