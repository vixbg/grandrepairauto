using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models.Contracts;
using GrandRepairAuto.Services;
using GrandRepairAuto.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace GrandRepairAuto.Web.APIControllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = "api")]
    public abstract class GenericAPIController<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO, TFilter> : ControllerBase
        where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
        where TPrimaryDTO : class, IDTO
        where TCreateDTO : class, IDTO
        where TUpdateDTO : class, IDTO
        where TFilter : class, IFilter<TEntity>
    {
        protected readonly IGenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service;

        public GenericAPIController(IGenericService<TEntity, TPrimaryKey, TPrimaryDTO, TCreateDTO, TUpdateDTO> service)
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
        public TPrimaryDTO GetByID(TPrimaryKey id)
        {
            var result = this.service.GetByID(id);
            if (result == null)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }

            return result;
        }

        [HttpPost()]
        public TPrimaryDTO Create(TCreateDTO entity)
        {
            //TODO: Insert TryCatch Block.

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

        [HttpPut("restore/{id}")]
        public TPrimaryDTO Restore(TPrimaryKey id)
        {
            var toRestore = this.service.Restore(id);

            if (toRestore == false)
            {
                Response.StatusCode = StatusCodes.Status404NotFound;
            }

            var result = this.service.GetByID(id);

            return result;
        }
    }
}
