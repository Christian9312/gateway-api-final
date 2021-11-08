using gateway_api_final.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Contracts
{
    public interface IGatewayRepository : IRepositoryBase<Gateway>
    {
        Task<IEnumerable<Gateway>> GetAllGateways();

        Task<Gateway> GetGatewayById(string serialNumber);

    }
}
