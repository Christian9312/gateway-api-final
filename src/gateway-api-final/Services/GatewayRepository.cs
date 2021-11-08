using gateway_api_final.Contracts;
using gateway_api_final.Entities;
using gateway_api_final.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Services
{
    public class GatewayRepository : RepositoryBase<Gateway>, IGatewayRepository
    {
        public GatewayRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Gateway>> GetAllGateways()
        {
            return await FindAll().OrderBy(gateway => gateway.Name).Include(x => x.AssociatedPeripherals).ToListAsync();
        }

        public async Task<Gateway> GetGatewayById(string serialNumber)
        {
            return await FindByCondition(gateway => gateway.SerialNumber == serialNumber).Include(x => x.AssociatedPeripherals)
                .FirstOrDefaultAsync();
        }

    }
}
