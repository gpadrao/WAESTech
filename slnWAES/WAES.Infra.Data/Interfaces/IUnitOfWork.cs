namespace WAES.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface that provides methods used in the Unit of Work implementation
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IUnitOfWork<TContext> where TContext : IDbContext, new()
    {
        void BeginTransaction();
        void SaveChanges();
    }
}
