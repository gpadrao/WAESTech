using Ninject.Modules;
using WAES.Domain.Interfaces.Services;
using WAES.Domain.Services;
using WAES.Domain.Interfaces.Repositories;
using WAES.Infra.Data.Repository;
using WAES.Infra.Data.Interfaces;
using WAES.Infra.Data.Context;
using WAES.Infra.Data.UoW;
using WAES.Application.Interfaces;
using WAES.Application;

namespace WAES.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Class where relations between interfaces and classes are created
    /// </summary>
    public class NinjectModulo : NinjectModule
    {
        public override void Load()
        {
            
            
            // data configs
            Bind(typeof(IContextManager<>)).To(typeof(ContextManager<>));
            Bind<IDbContext>().To<WAESModelContext>();
            Bind(typeof(IUnitOfWork<>)).To(typeof(UnitOfWork<>));

            // data repos
            Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            Bind<IWAESImageRepository>().To<WAESImageRepository>();

            // app
            Bind<IManageImagesAppService>().To<ManageImagesAppService>();

            // service
            Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            Bind<IWAESImageService>().To<WAESImageService>();

        }
    }
}
