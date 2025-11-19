using Company.Talabat.Domain.Contracts;
using Company.Talabat.Domain.Entities;

namespace Company.Talabat.Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Product, int> ProductRepository => throw new NotImplementedException();

        public IGenericRepository<ProductBrand, int> ProductBrandRepository => throw new NotImplementedException();

        public IGenericRepository<ProductCategory, int> ProductCategoryRepository => throw new NotImplementedException();

        public Task<int> CompleteAsync()
        {
            throw new NotImplementedException();
        }

        public ValueTask DisposeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
