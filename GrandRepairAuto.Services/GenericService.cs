using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models.Contracts;
using GrandRepairAuto.Repository;
using GrandRepairAuto.Services.Contracts;

namespace GrandRepairAuto.Services
{
    public class GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO>
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
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

        //DONE: GetAll Works.

        public IEnumerable<TPrimaryDTO> GetAll(IFilter<TEntity> filter)
        {
            var entities = this.repository.Get();
            if (filter != null)
            {
                entities = filter.Apply(entities);
            }
            return entities.Select(e => mapper.Map<TPrimaryDTO>(e));
        }

        //DONE: GetByID Works.

        public TPrimaryDTO GetByID(TPrimaryKey id) 
        {
            var entity = this.repository.GetByID(id);
            if (entity == null)
            {
                return null;
            }
            return mapper.Map<TPrimaryDTO>(entity);
        }

        //DONE: Create Works. Had to create a CreateDTO

        public TPrimaryDTO Create(TCreateDTO dto) 
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Insert(entity);
            return mapper.Map<TPrimaryDTO>(entity);
        }

        //DONE: Update Works. Either Have UpdateDTO or remove id from method.

        public TPrimaryDTO Update(TUpdateDTO dto, TPrimaryKey id) 
        {
            var entity = repository.GetByID(id);
            if (entity == null)
            {
                return null;
            }
            mapper.Map(dto, entity);
            repository.Update(entity);
            return mapper.Map<TPrimaryDTO>(entity);
        }

        //DONE: Delete WORKS.

        public bool Delete(TPrimaryKey id)
        {
            return repository.Delete(id);
        }

        //DONE: Restore WORKS.

        public bool Restore(TPrimaryKey id)
        {
            return repository.Restore(id);
        }
    }
}
