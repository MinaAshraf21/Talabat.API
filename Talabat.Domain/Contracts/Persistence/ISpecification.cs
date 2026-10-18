using System.Linq.Expressions;

namespace Talabat.Domain.Contracts.Persistence
{
    public interface ISpecification<TEntity , TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // where expression
        Expression<Func<TEntity, bool>>? Criteria { get; set; }

        // include expression
        // we don't know how many includes will be there so we use list
        // object because we don't know the type of the property to be included if it's a collection or single object
        List<Expression<Func<TEntity,object>>>? Includes { get; set; }

        Expression<Func<TEntity, object>>? OrderBy { get; set; }
        Expression<Func<TEntity, object>>? OrderByDescending { get; set; }

        int Skip { get; set; }
        int Take { get; set; }
        bool IsPagingEnabled { get; set; }

    }
}
