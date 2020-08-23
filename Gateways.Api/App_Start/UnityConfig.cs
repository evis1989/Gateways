using Gateways.Insfastructure.DI;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Gateways.Api.App_Start
{
    /// <summary>
    /// Config Unity Container
    /// </summary>
    /// 
    public static class UnityConfig
    {
        /// <summary>
        /// Register all components
        /// </summary>
        /// 
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            DependencyConfig.Configure(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}