using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Team13SmartGarage.Data.Models;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models;

namespace Team13SmartGarage.Web.Controllers.API
{
    public abstract class GenericAPIController<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> : ControllerBase
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
    {
        private readonly GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service;

        public GenericAPIController(GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service)
        {
            this.service = service;
        }

        [HttpGet()]
        public IEnumerable<TPrimaryDTO> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpGet("{id}")]
        public TPrimaryDTO GetByID(TPrimaryKey Id)
        {
            return this.service.GetByID(Id);
        }

        [HttpPost()]
        public TPrimaryDTO Create(TCreateDTO entity)
        {
            return this.service.Create(entity);
        }

        [HttpPut()]
        public TPrimaryDTO Update(TUpdateDTO entity)
        {
            return this.service.Update(entity);
        }

        [HttpDelete("{id}")]
        public bool Delete(TPrimaryKey id)
        {
            return this.service.Delete(id);
        }
    }
}
