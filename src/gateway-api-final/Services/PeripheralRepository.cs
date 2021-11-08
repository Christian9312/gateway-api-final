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
    public class PeripheralRepository : RepositoryBase<Peripheral>, IPeripheralRepository
    {
        public PeripheralRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Peripheral>> GetAllPeripherals()
        {
            return await FindAll().OrderBy(peripheral => peripheral.Vendor).Include(x => x.Gateway).ToListAsync();
        }

        public async Task<Peripheral> GetPeripheralById(uint id)
        {
            return await FindByCondition(gateway => gateway.UId == id).Include(x => x.Gateway)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Peripheral>> GetPeripheralByGateways(string gatewayNumber)
        {
            return await FindByCondition(peripheral => peripheral.GatewayId == gatewayNumber).ToListAsync();
        }
    }
}
