using AutoMapper;
using Talabat.Application.Abstractions.Services;
using Talabat.Application.Abstractions.Services.Products;
using Talabat.Application.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Domain.Contracts.Persistence;
using Talabat.Application.Abstractions.Services.Basket;
using Talabat.Application.Services.Baskets;

namespace Talabat.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _productService;
        private readonly Lazy<IBasketService> _basketService;

        public ServiceManager(Func<IProductService> productServiceFactory, Func<IBasketService> basketServiceFactory)
        {
           _productService = new Lazy<IProductService>(productServiceFactory);
           _basketService = new Lazy<IBasketService>(basketServiceFactory);
        }

        public IProductService ProductService => _productService.Value;

        public IBasketService BasketService => _basketService.Value;
    }
}
