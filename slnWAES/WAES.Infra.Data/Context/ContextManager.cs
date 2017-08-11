using System.Web;
using WAES.Infra.Data.Interfaces;

namespace WAES.Infra.Data.Context
{
    /// <summary>
    /// Class that includes the database context in the application context
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class ContextManager<TContext> : IContextManager<TContext> where TContext : IDbContext, new()
    {
        private const string ContextKey = "ContextManager.Context";
        public IDbContext GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new TContext();
            }

            return (IDbContext)HttpContext.Current.Items[ContextKey];
        }
    }
}
