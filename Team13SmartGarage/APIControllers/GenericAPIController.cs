using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Team13SmartGarage.Data.Filters.Contracts;
using Team13SmartGarage.Data.Models.Contracts;
using Team13SmartGarage.Services;
using Team13SmartGarage.Services.Models.Contracts;

namespace Team13SmartGarage.Web.APIControllers
{
    public abstract class GenericAPIController<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO, TFilter> : ControllerBase
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
        where TFilter : class, IFilter<TEntity>
    {
        private readonly GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service;

        public GenericAPIController(GenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service)
        {
            this.service = service;
        }

        [HttpGet()]
        public IEnumerable<TPrimaryDTO> GetAll([FromQuery] TFilter filter)
        {
            return this.service.GetAll(filter);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status404NotFound)]
        public TPrimaryDTO GetByID(TPrimaryKey Id)
        {
            var result = this.service.GetByID(Id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }

            return result;
        }

        [HttpPost()]
        public TPrimaryDTO Create(TCreateDTO entity)
        {
            return this.service.Create(entity);
        }

        [HttpPut("{id}")]
        public TPrimaryDTO Update(TUpdateDTO entity, TPrimaryKey id)
        {
            var result = this.service.Update(entity, id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }

            return result;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(TPrimaryKey id)
        {
            if (this.service.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
