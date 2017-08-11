namespace WAES.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface that provides a property to get the application database context
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public interface IContextManager<TContext> where TContext : IDbContext, new()
    {
        IDbContext GetContext();
    }
}
