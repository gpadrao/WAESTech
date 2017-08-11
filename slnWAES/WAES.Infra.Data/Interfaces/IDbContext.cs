﻿using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace WAES.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface that defines properties and methods to access database
    /// </summary>
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        DbEntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
        void Dispose();
    }
}
