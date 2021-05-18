using System.Linq;
using System.Collections.Generic;
using AutoMapper;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Repository;
using Team13SmartGarage.Services.Models;

namespace Team13SmartGarage.Services
{
    public class GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> 
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
    {
        private readonly GenericRepository<TEntity, TPrimaryKey> repository;
        private readonly IMapper mapper;

        public GenericService(GenericRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<TPrimaryDTO> GetAll()
        {
            return this.repository.Get().Select(e => mapper.Map<TPrimaryDTO>(e));
        }

        public TPrimaryDTO GetByID(TPrimaryKey id)
        {
            var entity = this.repository.GetByID(id);
            return mapper.Map<TPrimaryDTO>(entity);
        }

        public TPrimaryDTO Create(TCreateDTO dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Insert(entity);
            return mapper.Map<TPrimaryDTO>(entity);
        }

        public TPrimaryDTO Update(TUpdateDTO dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Update(entity);
            return mapper.Map<TPrimaryDTO>(entity);

        }

        public bool Delete(TPrimaryKey id)
        {
            repository.Delete(id);
            return true;
        }
    }
}
