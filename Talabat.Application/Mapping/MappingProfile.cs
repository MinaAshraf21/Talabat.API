using AutoMapper;
using Talabat.Application.Abstractions.DTOs.Products;
using Talabat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(dest => dest.Category, o => o.MapFrom(src => src.Category!.Name))
                .ForMember(dest => dest.Brand, o => o.MapFrom(src => src.Brand!.Name))
                .ForMember(dest => dest.ImageUrl, o => o.MapFrom<ProductImageUrlResolver>());

            CreateMap<ProductBrand, BrandDto>();
            CreateMap<ProductCategory, CategoryDto>();
        }
    }
}
