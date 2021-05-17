using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Repository;
using Team13SmartGarage.Services.Models;

namespace Team13SmartGarage.Services
{
    public class GenericService<TEntity, TPrimaryKey, TPrimaryDto, TCreateDto> 
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryDto : class, IDto
        where TCreateDto : class, IDto
    {
        private readonly GenericRepository<TEntity, TPrimaryKey> repository;
        private readonly IMapper mapper;

        public GenericService(GenericRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<TPrimaryDto> GetAll()
        {
            return this.repository.Get().Select(e => mapper.Map<TPrimaryDto>(e));
        }

        public TPrimaryDto Create(TCreateDto dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Insert(entity);
            return mapper.Map<TPrimaryDto>(entity);
        }
    }
}
