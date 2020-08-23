using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Threading.Tasks;
using Gateways.Core.ServiceModels;
using Gateways.Data.AbstractRepositories;
using Gateways.Data.Entities;

namespace Gateways.Service.PeripheralService
{
    public class PeripheralService : IPeripheralService
    {
        private readonly IGatewayRepository gatewayRepository;
        private readonly IPeripheralRepository peripheralRepository;
        private readonly IMapper mapper;

        public PeripheralService(IPeripheralRepository peripheralRepository, IGatewayRepository gatewayRepository, IMapper mapper)
        {
            this.peripheralRepository = peripheralRepository;
            this.gatewayRepository = gatewayRepository;
            this.mapper = mapper;
        }
        public void AddPeripheralAsync(Peripheral peripheral)
        {
             peripheralRepository.Add(mapper.Map<PeripheralEntity>(peripheral));
        }
        public async Task<IEnumerable<Peripheral>> GetAllPeripheralsAsync()
        {
            var entities = await peripheralRepository.GetAllAsync();
            return mapper.Map(entities, new List<Peripheral>());
        }
        public async Task<IEnumerable<Peripheral>> GetAllPeripheralsByGatewayIdAsync(long gatewayId)
        {
            var entities = await peripheralRepository.FindAsync(c => c.GatewayEntity.Id == gatewayId);
            return mapper.Map(entities, new List<Peripheral>());
        }

        public async Task<Peripheral> GetPeripheralByIdAsync(long? id)
        {
            var entity = await peripheralRepository.GetByIdAsync(id);
            return mapper.Map<Peripheral>(entity);
        }

        public void RemovePeripheralAsync(long? id)
        {
            peripheralRepository.RemoveAsync(id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await peripheralRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdatePeripheralAsync(Peripheral peripheral)
        {
            var entity = mapper.Map<PeripheralEntity>(peripheral);
            return await peripheralRepository.UpdateAsync(entity);
        }
    }
}
