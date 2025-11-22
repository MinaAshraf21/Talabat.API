using AutoMapper;
using Company.Talabat.Application.Abstractions.DTOs.Products;
using Company.Talabat.Application.Abstractions.Services.Products;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Domain.Entities;

namespace Company.Talabat.Application.Services.Products
{
    internal class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
    {
        public async Task<IEnumerable<ProductToReturnDto>> GetProductsAsync()
        {
            var products = await unitOfWork.GetRepository<Product, int>().GetAllAsync();

            var productsDto = mapper.Map<IEnumerable<ProductToReturnDto>>(products);

            return productsDto;
        }

        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {
            var product = await unitOfWork.GetRepository<Product, int>().GetByIdAsync(id);

            var productDto = mapper.Map<ProductToReturnDto>(product);

            return productDto;
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            var brands = await unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsDto = mapper.Map<IEnumerable<BrandDto>>(brands);

            return brandsDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesDto = mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }

    }
}
