using Talabat.Application.Abstractions.Common;
using Talabat.Application.Abstractions.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Application.Abstractions.Services.Products
{
    public interface IProductService
    {
        Task<Pagination<ProductToReturnDto>> GetProductsAsync(ProductsSpecificationParameters specificationParameters);
        Task<ProductToReturnDto> GetProductAsync(int id);
        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
