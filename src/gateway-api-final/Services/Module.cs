using gateway_api_final.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gateway_api_final.Services
{
    public static class Module
    {
        public static IServiceCollection AddWrapperServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
