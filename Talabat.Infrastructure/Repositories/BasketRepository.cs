using StackExchange.Redis;
using System.Text.Json;
using Talabat.Domain.Contracts.Infrastructure;
using Talabat.Domain.Entities.Basket;

namespace Talabat.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }
        public async Task<Basket?> GetAsync(string id)
        {
            var basket = await _database.StringGetAsync(id);
            return basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<Basket?>(basket!);
        }

        public async Task<Basket?> UpdateAsync(Basket basket, int timeToLive)
        {
            bool updated = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(timeToLive));
            if (!updated) return null;
            return basket;
        }
        public async Task DeleteAsync(string id)
        {
            await _database.KeyDeleteAsync(id);
        }
    }
}
