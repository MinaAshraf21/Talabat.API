using Talabat.Domain.Entities.Basket;

namespace Talabat.Domain.Contracts.Infrastructure
{
    public interface IBasketRepository
    {
        Task<Basket?> GetAsync(string id);
        Task<Basket?> UpdateAsync(Basket basket, int timeToLive);
        Task DeleteAsync(string id);
    }
}
