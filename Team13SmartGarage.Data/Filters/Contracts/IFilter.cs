using System.Linq;
using Team13SmartGarage.Data.Models.Contracts;

namespace Team13SmartGarage.Data.Filters.Contracts
{
    public interface IFilter<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Apply(IQueryable<TEntity> entities);
    }
}
