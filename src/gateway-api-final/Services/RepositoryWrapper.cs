using gateway_api_final.Contracts;
using gateway_api_final.Entities;
using gateway_api_final.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext appDbContext;
        private IGatewayRepository gateway;
        private IPeripheralRepository peripheral;

        public RepositoryWrapper(RepositoryContext context)
        {
            appDbContext = context;
        }

        public IGatewayRepository Gateway =>
            gateway ??= new GatewayRepository(appDbContext);

        public IPeripheralRepository Peripheral =>
            peripheral ??= new PeripheralRepository(appDbContext);



        public async Task<Response> SaveAsync()
        {
            try
            {
                await appDbContext.SaveChangesAsync();
                return new Response(true, string.Empty);
            }
            catch (Exception e)
            {
                return new Response(false, e.Message);
            }
        }
    }
}
