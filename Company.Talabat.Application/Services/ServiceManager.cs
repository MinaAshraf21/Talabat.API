using AutoMapper;
using Company.Talabat.Application.Abstractions.Services;
using Company.Talabat.Application.Abstractions.Services.Products;
using Company.Talabat.Application.Services.Products;
using Company.Talabat.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Application.Services
{
    internal class ServiceManager : IServiceManager
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly Lazy<IProductService> _productService;

        public ServiceManager(IUnitOfWork unitOfWork , IMapper mapper)
        {
           _unitOfWork = unitOfWork;
           _mapper = mapper;
           _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork, _mapper));
        }

        public IProductService ProductService => _productService.Value;
    }
}
