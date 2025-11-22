using AutoMapper;
using Company.Talabat.Application.Abstractions.DTOs.Products;
using Company.Talabat.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Company.Talabat.Application.Mapping
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
