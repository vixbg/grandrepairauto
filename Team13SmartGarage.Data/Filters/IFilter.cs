using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Team13SmartGarage.Data.Models;

namespace Team13SmartGarage.Data.Filters
{
    public interface IFilter<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
}
