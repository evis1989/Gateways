using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Gateways.Insfastructure.DI;

namespace Gateways.App_Start
{
    public class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            DependencyConfig.Configure(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}