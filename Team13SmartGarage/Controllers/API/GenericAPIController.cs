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
    public abstract class GenericAPIController<TEntity, TPrimaryKey, TPrimaryDto, TCreateDto> : ControllerBase
        where TEntity : class, IEntity<TPrimaryKey>
        where TPrimaryDto : class, IDto
        where TCreateDto : class, IDto
    {
        private readonly GenericService<TEntity, TPrimaryKey, TPrimaryDto, TCreateDto> service;

        public GenericAPIController(GenericService<TEntity, TPrimaryKey, TPrimaryDto, TCreateDto> service)
        {
            this.service = service;
        }

        [HttpGet()]
        public IEnumerable<TPrimaryDto> GetAll()
        {
            return this.service.GetAll();
        }

        [HttpPost()]
        public TPrimaryDto Create(TCreateDto entity)
        {
            return this.service.Create(entity);
        }
    }
}
