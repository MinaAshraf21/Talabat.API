using Talabat.Application.Abstractions.Services.Products;

namespace Talabat.Application.Abstractions.Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
