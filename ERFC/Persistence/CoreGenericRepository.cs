using System;
using System.Collections.Generic;
using System.Linq;
using ERFC.Core.Repositories;
using System.Data.Entity;
using FscCore.Core;
using System.Data;
using ERFC.Core;

namespace ERFC.Persistence
{
    public class CoreGenericRepository<TEntity> : IRepositoryWeb<TEntity> where TEntity : class
    {
        internal ERFCDBEntities context;
        internal DbSet<TEntity> dbSet;

        public CoreGenericRepository(ERFCDBEntities pcontext)
        {
            this.context = pcontext;
            this.dbSet = this.context.Set<TEntity>();
        }

        //get all
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;
            return query.ToList();
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }
        public TEntity Get(Func<TEntity, Boolean> where)
        {
            return dbSet.Where(where).FirstOrDefault<TEntity>();
           
        }

        public virtual IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return dbSet.Where(where).ToList();
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public void Delete(Func<TEntity, Boolean> where)
        {
            IQueryable<TEntity> objects = dbSet.Where<TEntity>(where).AsQueryable();
            foreach (TEntity obj in objects)
                dbSet.Remove(obj);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public int Count<T>()
        {
            return dbSet.Count();
        }

    }
}