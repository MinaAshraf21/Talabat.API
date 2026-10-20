using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Application.Abstractions.DTOs.Basket;
using Talabat.Application.Abstractions.Services;

namespace Talabat.APIs.Controllers.Controllers
{
    public class BasketController(IServiceManager serviceManager) : BaseApiController
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string id)
        {
            var basket = await serviceManager.BasketService.GetCustomerBasketAsync(id);
            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<BasketDto>> UpdateBasket([FromBody]BasketDto basketDto)
        {
            var basket = await serviceManager.BasketService.UpdateCustomerBasketAsync(basketDto);
            return Ok(basket);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBasket(string id)
        {
            await serviceManager.BasketService.DeleteBasketAsync(id);
            return NoContent();
        }
    }
}
