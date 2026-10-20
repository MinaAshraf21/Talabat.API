using Talabat.Application.Abstractions.DTOs.Basket;
using Talabat.Application.Abstractions.Services.Basket;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Application.Exceptions;
using AutoMapper;
using Talabat.Domain.Entities.Basket;
using Microsoft.Extensions.Configuration;

namespace Talabat.Application.Services.Baskets
{
    public class BasketService
    (
        IBasketRepository _basketRepository,
        IMapper _mapper,
        IConfiguration _config
    ) : IBasketService
    {
        public async Task<BasketDto> GetCustomerBasketAsync(string id)
        {
            var basket = await _basketRepository.GetAsync(id);
            if (basket is null)
                throw new NotFoundException(nameof(Basket), id);

            var basketDto = _mapper.Map<BasketDto>(basket);
            return basketDto;
        }

        public async Task<BasketDto> UpdateCustomerBasketAsync(BasketDto basketDto)
        {
            var basket = _mapper.Map<Basket>(basketDto);

            var timeToLive = int.Parse(_config.GetSection("RedisSettings")["TimeToLiveInDays"]!);

            var updatedBasket = await _basketRepository.UpdateAsync(basket, timeToLive);

            return basketDto;
        }

        public async Task DeleteBasketAsync(string id)
        {
            await _basketRepository.DeleteAsync(id);
        }
    }
}
