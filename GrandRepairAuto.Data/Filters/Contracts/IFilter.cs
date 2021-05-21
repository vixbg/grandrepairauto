using System.Linq;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Data.Filters.Contracts
{
    public interface IFilter<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
}
