using Company.Talabat.Application.Abstractions.Services.Products;

namespace Company.Talabat.Application.Abstractions.Services
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
    }
}
