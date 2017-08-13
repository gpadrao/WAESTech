using Ninject;
using System.Web.Http.Dependencies;

namespace WAES.Web
{
    /// <summary>
    /// Implementing the NInject resolver
    /// </summary>
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }
}