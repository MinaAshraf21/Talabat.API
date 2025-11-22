using Company.Talabat.Domain.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Domain.Specifications
{
    public class BaseSpecifications<TEntity, TKey> : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>>? Criteria { get; set; } = null;
        public List<Expression<Func<TEntity, object>>>? Includes { get; set; } = new();

        public BaseSpecifications()
        {
            
        }

        public BaseSpecifications(TKey id)
        {
            Criteria = e => e.Id.Equals(id);
        }
    }
}
