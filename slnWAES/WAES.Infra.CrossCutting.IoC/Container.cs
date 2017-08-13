using CommonServiceLocator.NinjectAdapter.Unofficial;
using Microsoft.Practices.ServiceLocation;
using Ninject;

namespace WAES.Infra.CrossCutting.IoC
{
    /// <summary>
    /// Class responsible for instantiating and manage the IoC provided by Ninject Nuget Package. This class is referenced in the WebApiConfig.cs file at "WAES.Web" project.
    /// </summary>
    public class Container
    {
        /// <summary>
        /// Class constructor. Calls the ninject service where all relations between Interfaces and Classes are build
        /// </summary>
        public Container()
        {
            ServiceLocator.SetLocatorProvider(() => new NinjectServiceLocator(GetModule()));
        }

        /// <summary>
        /// Method that creates and returns all mapped relations between Interfaces and Classes, for Ioc mapping
        /// </summary>
        /// <returns></returns>
        public StandardKernel GetModule()
        {
            return new StandardKernel(new NinjectModulo());
        }
    }
}
