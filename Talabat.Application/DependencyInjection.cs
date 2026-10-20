using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Talabat.Application.Abstractions.Services;
using Talabat.Application.Abstractions.Services.Basket;
using Talabat.Application.Abstractions.Services.Products;
using Talabat.Application.Mapping;
using Talabat.Application.Services.Baskets;
using Talabat.Application.Services.Products;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Contracts.Persistence;

namespace Talabat.Application
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

            services.AddScoped(typeof(Func<IBasketService>), sp =>
            {
                var config = sp.GetRequiredService<IConfiguration>();
                var mapper = sp.GetRequiredService<IMapper>();
                var repo = sp.GetRequiredService<IBasketRepository>();

                return () => new BasketService(repo, mapper, config);
            });

            services.AddScoped(typeof(Func<IProductService>), sp =>
            {
                var uow = sp.GetRequiredService<IUnitOfWork>();
                var mapper = sp.GetRequiredService<IMapper>();

                return () => new ProductService(uow, mapper);
            });

            return services;
        }
    }
}
