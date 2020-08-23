using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gateways.Core.ServiceModels;

namespace Gateways.Service.PeripheralService
{
    public interface IPeripheralService
    {
        Task<IEnumerable<Peripheral>> GetAllPeripheralsAsync();
        Task<IEnumerable<Peripheral>> GetAllPeripheralsByGatewayIdAsync(long gatewayId);
        Task<Peripheral> GetPeripheralByIdAsync(long? id);
        void AddPeripheralAsync(Peripheral peripheral);
        void RemovePeripheralAsync(long? id);
        Task<bool> UpdatePeripheralAsync(Peripheral peripheral);
        Task<bool> SaveChangesAsync();
    }
}
