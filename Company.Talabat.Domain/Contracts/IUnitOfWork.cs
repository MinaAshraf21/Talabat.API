using Company.Talabat.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Domain.Contracts
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IGenericRepository<Product,int> ProductRepository { get; }
        IGenericRepository<ProductBrand,int> ProductBrandRepository { get; }
        IGenericRepository<ProductCategory,int> ProductCategoryRepository { get; }

        Task<int> CompleteAsync();
    }
}
