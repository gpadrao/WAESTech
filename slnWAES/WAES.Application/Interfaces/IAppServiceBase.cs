using WAES.Infra.Data.Interfaces;

namespace WAES.Application.Interfaces
{
    public interface IAppServiceBase<TContext> where TContext : IDbContext
    {
        void BeginTransaction();
        void Commit();
    }
}
