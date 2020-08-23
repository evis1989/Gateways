using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Gateways.Core.ServiceModels;

namespace Gateways.Service.PeripheralService
{
    public interface IGatewayService
    {
        Task<Gateway> GetByIdAsync(long? id);
        Task<IEnumerable<Gateway>> GetAllGatewaysAsync();
        void AddGatewayAsync(Gateway model);
        Task<bool> UpdateGatewayAsync(Gateway model);
        Task<bool> SaveChangesAsync();
    }
}
