namespace Talabat.Domain.Contracts.Persistence
{
    public interface IGenericRepository<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool withTracking = false);
        Task<IEnumerable<TEntity>> GetAllWithSpecsAsync(ISpecification<TEntity, TKey> specification, bool withTracking = false);
        Task<int> GetCountAsync(ISpecification<TEntity, TKey> specification);

        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TEntity> GetWithSpecsAsync(ISpecification<TEntity, TKey> specification);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
