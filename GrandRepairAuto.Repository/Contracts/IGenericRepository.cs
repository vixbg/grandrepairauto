using System;
using System.Linq;
using System.Linq.Expressions;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Repository.Contracts
{
    public interface IGenericRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy,
            string includeProperties);

        TEntity GetByID(TPrimaryKey id);

        void Insert(TEntity entity);

        void Delete(TPrimaryKey id);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}