using Talabat.Application.Abstractions.DTOs.Basket;

namespace Talabat.Application.Abstractions.Services.Basket
{
    public interface IBasketService
    {
        Task<BasketDto> GetCustomerBasketAsync(string id);
        Task<BasketDto> UpdateCustomerBasketAsync(BasketDto basketDto);
        Task DeleteBasketAsync(string id);
    }
}
