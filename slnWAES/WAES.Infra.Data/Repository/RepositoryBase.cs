using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using WAES.Domain.Interfaces.Repositories;
using WAES.Infra.Data.Context;
using WAES.Infra.Data.Interfaces;

namespace WAES.Infra.Data.Repository
{
    /// <summary>
    /// Class that implements the "Repository Pattern" providing database access to manipulate the entities within the context
    /// </summary>
    /// <typeparam name="TEntity">Entity that will be manipulated</typeparam>
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity>
        where TEntity : class
       , new()
    {
        /// <summary>
        /// Establishing the proper context to access data 
        /// </summary>
        private readonly ContextManager<WAESModelContext> _contextManager = ServiceLocator.Current.GetInstance<IContextManager<WAESModelContext>>() as ContextManager<WAESModelContext>;

        protected IDbSet<TEntity> DbSet;
        protected readonly IDbContext Context;

        public RepositoryBase()
        {
            Context = _contextManager.GetContext();
            DbSet = Context.Set<TEntity>();
        }

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual TEntity GetById(Guid id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual IEnumerable<TEntity> GetAllReadOnly()
        {
            return DbSet.AsNoTracking();
        }

        public virtual void Update(TEntity obj)
        {
            var entry = Context.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
        }

        public virtual void Remove(TEntity obj)
        {
            DbSet.Remove(obj);
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
