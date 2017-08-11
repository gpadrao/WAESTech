using System;
using System.Collections.Generic;

namespace WAES.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface that provides generic methods for all services
    /// Implementing the "Service Design Pattern "
    /// </summary>
    /// <typeparam name="TEntity">Entity that will be manipulated</typeparam>
    public interface IServiceBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
        void Dispose();
    }
}
