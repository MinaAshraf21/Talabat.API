using Company.Talabat.Domain.Common;
using Company.Talabat.Domain.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Company.Talabat.Infrastructure.Persistence.Repositories.GenericRepository
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

            string s = "";
            if(specification.Includes is not null)
            {
                query = specification.Includes
                                     .Aggregate(query, (currentQuery, includeExpression) => currentQuery.Include(includeExpression));
            }

            ///query = _dbcontext.Set<TEntity>().Where(q => q.Id.Equals(id));
            ///query = query.Include(e => e.RelatedEntity1);
            ///query = query.Include(e => e.RelatedEntity1).Include(e => e.RelatedEntity2);
            return query;
        }
    }
}
