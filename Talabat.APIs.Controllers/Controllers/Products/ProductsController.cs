using Talabat.APIs.Controllers.Controllers.Base;
using Talabat.Application.Abstractions.Common;
using Talabat.Application.Abstractions.DTOs.Products;
using Talabat.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;

namespace Talabat.APIs.Controllers.Controllers.Products
{
    public class ProductsController(IServiceManager _serviceManager) : BaseApiController
    {

        [HttpGet] //GET: /api/products
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetAllProducts
            ([FromQuery]ProductsSpecificationParameters specParams)
        {
            var products = await _serviceManager.ProductService.GetProductsAsync(specParams);
            return Ok(products);
        }

        [HttpGet("{id}")] //GET: /api/products/id
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _serviceManager.ProductService.GetProductAsync(id);
            if (product == null) return NotFound(new {StatusCode = 404 , Message = "Not Found!"});
            return Ok(product);
        }

        [HttpGet("brands")] //GET: /api/products/brands
        public async Task<ActionResult<IEnumerable<BrandDto>>> GetAllBrands()
        {
            var brands = await _serviceManager.ProductService.GetBrandsAsync();
            return Ok(brands);
        }

        [HttpGet("categories")] //GET: /api/products/categories
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAllCategories()
        {
            var categories = await _serviceManager.ProductService.GetCategoriesAsync();
            return Ok(categories);
        }

    }
}
