using AutoMapper;
using Talabat.Application.Abstractions.DTOs.Products;
using Microsoft.Extensions.Configuration;
using Talabat.Domain.Entities.Products;

namespace Talabat.Application.Mapping
{
    internal class ProductImageUrlResolver(IConfiguration configuration) : IValueResolver<Product, ProductToReturnDto, string?>
    {
        public string? Resolve(Product source, ProductToReturnDto destination, string? destMember, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source.ImageUrl))
                return string.Empty;

            return $"{configuration["URLs:ApiBaseUrl"]}/{source.ImageUrl}";
        }
    }
}
