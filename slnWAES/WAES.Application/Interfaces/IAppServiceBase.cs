using WAES.Infra.Data.Interfaces;

namespace WAES.Application.Interfaces
{
    /// <summary>
    /// Interface that provides methods to access the context database to persist objects
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}
