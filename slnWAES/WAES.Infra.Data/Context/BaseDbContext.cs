using System.Data.Entity;
using WAES.Infra.Data.Interfaces;

namespace WAES.Infra.Data.Context
{
    /// <summary>
    /// Class that implement database context mapping all available entities
    /// </summary>
    public class BaseDbContext : DbContext, IDbContext
    {
        public BaseDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
