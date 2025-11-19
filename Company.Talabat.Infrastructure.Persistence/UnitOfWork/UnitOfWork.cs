using Company.Talabat.Domain.Common;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Domain.Entities;
using Company.Talabat.Infrastructure.Persistence.Data;
using Company.Talabat.Infrastructure.Persistence.Repositories;
using System.Collections.Concurrent;

namespace Company.Talabat.Infrastructure.Persistence.UnitOfWork
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly StoreContext _storeContext;
        //private readonly Dictionary<string, object> _repositories;
        //when working asyncronously it's better to use Concurrent data structures
        private readonly ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreContext storeContext , ConcurrentDictionary<string ,object> repositories)
        {
            _storeContext = storeContext;
            _repositories = repositories;
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            ////if (_repositories.ContainsKey(nameof(TEntity)))
            ////    return (IGenericRepository<TEntity, TKey>) _repositories[nameof(TEntity)];

            ////var repository = new GenericRepository<TEntity, TKey>(_storeContext);
            ////_repositories.Add(nameof(TEntity), repository);
            ////return repository;

            return (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(nameof(TEntity), new GenericRepository<TEntity, TKey>(_storeContext));
        }

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
