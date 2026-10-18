using AutoMapper;
using Company.Talabat.Application.Abstractions.Common;
using Company.Talabat.Application.Abstractions.DTOs.Products;
using Company.Talabat.Application.Abstractions.Services.Products;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Domain.Entities;
using Company.Talabat.Domain.Specifications.Products;

namespace Company.Talabat.Application.Services.Products
{
    internal class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<Pagination<ProductToReturnDto>> GetProductsAsync
            (ProductsSpecificationParameters specParams)
        {

            var productRepository = _unitOfWork.GetRepository<Product, int>();

            var spec = new ProductWithBrandAndCategorySpecifications(specParams.Sort, specParams.CategoryId, specParams.BrandId, specParams.PageSize, specParams.PageIndex,specParams.Search);
            
            var products = await productRepository.GetAllWithSpecsAsync(spec);

            var countSpec = new ProductWithBrandAndCategorySpecifications(specParams.CategoryId, specParams.BrandId,specParams.Search);
            
            var count = await productRepository.GetCountAsync(countSpec);

            var productsDto = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);


            return new Pagination<ProductToReturnDto>
                (specParams.PageIndex, specParams.PageSize)
            {
                Count = count,
                Data = productsDto 
            };
                
        }
        
        public async Task<ProductToReturnDto> GetProductAsync(int id)
        {

            var spec = new ProductWithBrandAndCategorySpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetWithSpecsAsync(spec);

            var productDto = _mapper.Map<ProductToReturnDto>(product);

            return productDto;
        }

        public async Task<IEnumerable<BrandDto>> GetBrandsAsync()
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand, int>().GetAllAsync();

            var brandsDto = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return brandsDto;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var categories = await _unitOfWork.GetRepository<ProductCategory, int>().GetAllAsync();

            var categoriesDto = _mapper.Map<IEnumerable<CategoryDto>>(categories);

            return categoriesDto;
        }

    }
}
