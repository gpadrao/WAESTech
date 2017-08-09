using System.Data.Entity;
using WAES.Infra.Data.Interfaces;

namespace WAES.Infra.Data.Context
{
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
