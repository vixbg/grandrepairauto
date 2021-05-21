using System.Linq;
using GrandRepairAuto.Data.Filters.Contracts;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Filters
{
    public class NoFilter<TEntity> : IFilter<TEntity> where TEntity : class, IEntity
    {
        public IQueryable<TEntity> Apply(IQueryable<TEntity> entities)
        {
            return entities;
        }
    }
}
