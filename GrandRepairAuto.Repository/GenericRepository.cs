﻿using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GrandRepairAuto.Data;
using GrandRepairAuto.Data.Models.Contracts;

namespace GrandRepairAuto.Repository
{
    public class GenericRepository<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>, ISoftDeletable
    {
        internal GarageContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(GarageContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            query = query.Where(e => e.DeletedOn == null);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }
            else
            {
                return query;
            }
        }

        public virtual TEntity GetByID(TPrimaryKey id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual bool Delete(TPrimaryKey id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            return Delete(entityToDelete);
        }

        public virtual bool Delete(TEntity entityToDelete)
        {
            if (entityToDelete == null)
            {
                return false;
            }

            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            entityToDelete.DeletedOn = DateTime.Now;

            context.SaveChanges();

            return true;
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
