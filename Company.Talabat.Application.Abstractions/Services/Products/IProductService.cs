using Company.Talabat.Application.Abstractions.DTOs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Application.Abstractions.Services.Products
{
    public interface IProductService
    {
        Task<IEnumerable<ProductToReturnDto>> GetProductsAsync();
        Task<ProductToReturnDto> GetProductAsync(int id);
        Task<IEnumerable<BrandDto>> GetBrandsAsync();
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync();
    }
}
