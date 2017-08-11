using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace WAES.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface that defines the common methods used to manipulate data
    /// Implementing the "Repository Design Pattern"
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
    }
}
