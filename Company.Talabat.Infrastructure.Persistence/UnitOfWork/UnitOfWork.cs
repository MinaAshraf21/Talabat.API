using Company.Talabat.Domain.Common;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Infrastructure.Persistence.Data;
using Company.Talabat.Infrastructure.Persistence.Repositories.GenericRepository;
using System.Collections.Concurrent;

namespace Company.Talabat.Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        //private readonly Dictionary<string, object> _repositories;
        //when working asyncronously it's better to use Concurrent data structures
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreContext storeContext)
        {
            _storeContext = storeContext;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(nameof(TEntity), new GenericRepository<TEntity, TKey>(_storeContext));
        }

        public async Task<int> CompleteAsync()
        {
            return await _storeContext.SaveChangesAsync();
        }

        public ValueTask DisposeAsync()
        {
            return _storeContext.DisposeAsync();
        }

    }
}
