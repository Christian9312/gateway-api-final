using gateway_api_final.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Contracts
{
    public interface IRepositoryWrapper
    {
        IGatewayRepository Gateway { get; }
        IPeripheralRepository Peripheral { get; }
        Task<Response> SaveAsync();
    }
}
