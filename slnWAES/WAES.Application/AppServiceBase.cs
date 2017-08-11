using Microsoft.Practices.ServiceLocation;
using WAES.Application.Interfaces;
using WAES.Infra.Data.Interfaces;

namespace WAES.Application
{
    /// <summary>
    /// This class implements the Unit of Work design pattern that will define the proper context that will be used by methods within AppService classes
    /// </summary>
    /// <typeparam name="TContext"></typeparam>
    public class AppServiceBase<TContext> : IAppServiceBase<TContext> where TContext : IDbContext, new()
    {
        /// <summary>
        /// Instance of Unit Of Work context
        /// </summary>
        private IUnitOfWork<TContext> _uow;

        /// <summary>
        /// Starts a transaction, which ensures the atomicity of data, retrieving the correct database context
        /// </summary>
        public virtual void BeginTransaction()
        {
            _uow = ServiceLocator.Current.GetInstance<IUnitOfWork<TContext>>();
            _uow.BeginTransaction();
        }

        /// <summary>
        /// Presists data into database
        /// </summary>
        public virtual void Commit()
        {
            _uow.SaveChanges();
        }
       
    }
}
