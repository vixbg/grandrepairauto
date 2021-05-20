using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Data.Filters
{
    public class NoFilter<TEntity> : IFilter<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            return entities;
        }
    }
}
