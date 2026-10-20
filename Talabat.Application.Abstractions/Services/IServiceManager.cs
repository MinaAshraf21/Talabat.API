using Talabat.Application.Abstractions.Services.Basket;
using Talabat.Application.Abstractions.Services.Products;

namespace Talabat.Application.Abstractions.Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        IBasketService BasketService { get; }
    }
}
