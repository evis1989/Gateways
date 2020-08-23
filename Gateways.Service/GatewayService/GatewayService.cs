using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Gateways.Core.ServiceModels;
using Gateways.Data.AbstractRepositories;
using Gateways.Data.Entities;
using Gateways.Service.PeripheralService;

namespace Gateways.Service.GatewayService
{
    public class GatewayService : IGatewayService
    {
        private readonly IGatewayRepository gatewayRepository;
        private readonly IPeripheralRepository peripheralRepository;
        private readonly IMapper mapper;
        public GatewayService(IGatewayRepository gatewayRepository, IPeripheralRepository peripheralRepository, IMapper mapper)
        {
            this.gatewayRepository = gatewayRepository;
            this.peripheralRepository = peripheralRepository;
            this.mapper = mapper;
        }
        public void AddGatewayAsync(Gateway model)
        {
            gatewayRepository.Add(mapper.Map<GatewayEntity>(model));
        }

        public async Task<IEnumerable<Gateway>> GetAllGatewaysAsync()
        {
            var gatewayEntities = await gatewayRepository.GetAllAsync();
            return mapper.Map(gatewayEntities, new List<Gateway>());
        }

        public async Task<Gateway> GetByIdAsync(long? id)
        {
            var gatewayEntity = await gatewayRepository.GetByIdAsync(id);
            return mapper.Map<Gateway>(gatewayEntity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await gatewayRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateGatewayAsync(Gateway model)
        {
            return await gatewayRepository.UpdateAsync(mapper.Map<GatewayEntity>(model));
        }
    }
}
