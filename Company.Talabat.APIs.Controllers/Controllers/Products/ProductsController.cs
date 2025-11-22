using Company.Talabat.APIs.Controllers.Controllers.Base;
using Company.Talabat.Application.Abstractions.DTOs.Products;
using Company.Talabat.Application.Abstractions.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.APIs.Controllers.Controllers.Products
{
   [Route("/api/[controller]/")]
    public class ProductsController(IServiceManager _serviceManager) : BaseApiController
    {

        [HttpGet] //GET: /api/products
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAllProducts()
        {
            var products = await _serviceManager.ProductService.GetProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")] //GET: /api/products/id
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var product = await _serviceManager.ProductService.GetProductAsync(id);
            if (product == null) return NotFound();
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
