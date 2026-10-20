using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Infrastructure.Repositories;

namespace Talabat.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(typeof(IConnectionMultiplexer),  sp =>
            {
                var connstr = configuration.GetConnectionString("redis");
                var connMultiplexer = ConnectionMultiplexer.Connect(connstr!);
                return connMultiplexer;
            });

            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }

    }
}
