using Talabat.Domain.Common;
using Talabat.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Talabat.Infrastructure.Persistence.Repositories.GenericRepository
{
    internal static class SpecificationsEvaluator<TEntity,TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecification<TEntity, TKey> specification)
        {
            var query = inputQuery; // _dbcontext.Set<TEntity>();

            if (specification.Criteria is not null)
                query = query.Where(specification.Criteria);


            if (specification.OrderBy is not null)
                query = query.OrderBy(specification.OrderBy);
            else if (specification.OrderByDescending is not null)
                query = query.OrderByDescending(specification.OrderByDescending);

            if (specification.IsPagingEnabled)
                query = query.Skip(specification.Skip).Take(specification.Take);
            
            if (specification.Includes is not null)
                specification.Includes.ForEach(i => { query = query.Include(i); });

            ///query = _dbcontext.Set<TEntity>().Where(q => q.Id.Equals(id));
            ///query = query.Include(e => e.RelatedEntity1);
            ///query = query.Include(e => e.RelatedEntity1).Include(e => e.RelatedEntity2);
            return query;
        }
    }
}
