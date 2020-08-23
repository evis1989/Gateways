using AutoMapper;
using Gateways.Data.AbstractRepositories;
using Gateways.Insfastructure.AppContext;
using Gateways.Insfastructure.AutoMapper;
using Gateways.Insfastructure.Repositories;
using Gateways.Service.GatewayService;
using Gateways.Service.PeripheralService;
using Unity;
using Unity.Lifetime;

namespace Gateways.Insfastructure.DI
{
    public static class DependencyConfig
    {
        public static void Configure(UnityContainer container)
        {
            #region DbContext
            container.RegisterType<IDbContext,SQLDbContext>(new TransientLifetimeManager());
            #endregion

            #region AutoMapper
            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfile>();
            });
            container.RegisterInstance(config.CreateMapper());
            #endregion

            #region Repositories
            container.RegisterType<IPeripheralRepository, PeripheralRepository>(new TransientLifetimeManager());
            container.RegisterType<IGatewayRepository, GatewayRepository>(new TransientLifetimeManager());
            #endregion

            #region Services
            container.RegisterType<IPeripheralService, PeripheralService>(new TransientLifetimeManager());
            container.RegisterType<IGatewayService, GatewayService>(new TransientLifetimeManager());
            #endregion

        }
    }
}
