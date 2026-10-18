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
        public Expression<Func<TEntity, object>>? OrderBy { get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDescending { get; set; } = null;
        public int Skip { get; set; } = 0;
        public int Take { get; set; } = 0;
        public bool IsPagingEnabled { get; set; } = false;

        public BaseSpecifications(Expression<Func<TEntity, bool>>? criteria)
        {
            Criteria = criteria;
        }

        public BaseSpecifications(TKey id)
        {
            Criteria = e => e.Id.Equals(id);
        }

        private protected virtual void AddIncludes()
        {
            // to be overridden in derived classes
        }

        private protected virtual void AddSorting(string? sort)
        {
            // to be overridden in derived classes
        }


        private protected virtual void AddOrderBy(Expression<Func<TEntity, object>>? orderBy)
        {
            OrderBy = orderBy;
        }
        private protected virtual void AddOrderByDescending(Expression<Func<TEntity, object>>? orderByDescending)
        {
            OrderByDescending = orderByDescending;
        }

        private protected virtual void AddPagination(int skip,int take)
        {
            IsPagingEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
