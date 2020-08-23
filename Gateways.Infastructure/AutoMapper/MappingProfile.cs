using AutoMapper;
using Gateways.Core.ServiceModels;
using Gateways.Core.ViewModels;
using Gateways.Data.Entities;
using System.Linq;

namespace Gateways.Insfastructure.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Peripheral, PeripheralEntity>();
            CreateMap<PeripheralEntity, Peripheral>();

            CreateMap<PeripheralViewModel, Peripheral>();
            CreateMap<Peripheral, PeripheralViewModel>();

            CreateMap<Gateway, GatewayEntity>();
            CreateMap<GatewayEntity, Gateway>();

            CreateMap<GatewayViewModel, Gateway>();
            CreateMap<Gateway, GatewayViewModel>();

            CreateMap<GatewayEntity, Gateway>()
                .ForMember(dest => dest.TotalPeripherals, opt => opt.MapFrom(src => src.Peripherals.Count()));

        }
    }
}
