using Company.Talabat.Domain.Common;
using Company.Talabat.Domain.Contracts;
using Company.Talabat.Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey>(StoreContext _storeContext) : IGenericRepository<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false)
        {
            if (withTracking)
                return await _storeContext.Set<TEntity>().ToListAsync();
            return await _storeContext.Set<TEntity>().AsNoTracking().ToListAsync();

        }

        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            return await _storeContext.FindAsync<TEntity>(id);
        }

        public async Task AddAsync(TEntity entity) => await _storeContext.AddAsync(entity);

        public void Delete(TEntity entity) => _storeContext.Remove(entity);

        public void Update(TEntity entity) => _storeContext.Update(entity);

    }
}
