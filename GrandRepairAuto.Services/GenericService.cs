﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models.Contracts;
using GrandRepairAuto.Repository.Contracts;
using GrandRepairAuto.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GrandRepairAuto.Services
{
    public abstract class GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> : IGenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO>
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
    {
        protected readonly IGenericRepository<TEntity, TPrimaryKey> repository;
        protected readonly IMapper mapper;

        public GenericService(IGenericRepository<TEntity, TPrimaryKey> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<TPrimaryDTO> GetAll(IFilter<TEntity> filter)
        {
            var entities = this.repository.Get();
            if (filter != null)
            {
                entities = filter.Apply(entities);
            }
            return entities.Select(e => mapper.Map<TPrimaryDTO>(e));
        }

        public IEnumerable<TPrimaryDTO> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            return this.repository.Get(filter).ProjectTo<TPrimaryDTO>(mapper.ConfigurationProvider).ToList();
        }

        public TPrimaryDTO GetByID(TPrimaryKey id)
        {
            var entity = this.repository.GetByID(id);
            if (entity == null)
            {
                return null;
            }
            return mapper.Map<TPrimaryDTO>(entity);
        }

        public TPrimaryDTO Create(TCreateDTO dto)
        {
            var entity = mapper.Map<TEntity>(dto);
            repository.Insert(entity);
            return mapper.Map<TPrimaryDTO>(entity);
        }

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

        public bool Delete(TPrimaryKey id)
        {
            return repository.Delete(id);
        }

        public bool Restore(TPrimaryKey id)
        {
            return repository.Restore(id);
        }
    }
}
