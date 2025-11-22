using System.Linq.Expressions;

namespace Company.Talabat.Domain.Contracts.Persistence
{
    public interface ISpecification<TEntity , TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        // where expression
        public Expression<Func<TEntity, bool>>? Criteria { get; set; }

        // include expression
        // we don't know how many includes will be there so we use list
        // object because we don't know the type of the property to be included if it's a collection or single object
        public List<Expression<Func<TEntity,object>>>? Includes { get; set; }
    }
}
