using System;
using System.Linq;
using System.Linq.Expressions;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Repository.Contracts
{
    public interface IGenericRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
    {
        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        TEntity GetByID(TPrimaryKey id);

        void Insert(TEntity entity);

        bool Delete(TPrimaryKey id);

        bool Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);

        bool Restore(TPrimaryKey id);

        bool Restore(TEntity entityToRestore);
    }
}