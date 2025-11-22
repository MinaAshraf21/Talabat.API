using AutoMapper;
using Company.Talabat.Application.Abstractions.Services;
using Company.Talabat.Application.Abstractions.Services.Products;
using Company.Talabat.Application.Mapping;
using Company.Talabat.Application.Services.Products;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            services.AddScoped<ProductImageUrlResolver>();

            services.AddScoped<IServiceManager, Services.ServiceManager>();

            return services;
        }
    }
}
