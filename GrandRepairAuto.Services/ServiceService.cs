﻿using AutoMapper;
using GrandRepairAuto.Data.Models;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using GrandRepairAuto.Services.Models.ServiceDTOs;

namespace GrandRepairAuto.Services
{
    public class ServiceService : GenericService<Service, int, ServiceDTO, ServiceCreateDTO, ServiceUpdateDTO>, IServiceService
    {
        public ServiceService(IServiceRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
