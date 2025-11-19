using Company.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Infrastructure.Persistence.Data.Config
{
    internal class BaseAuditableEntityConfigurations<TEntity, TKey> : BaseEntityConfigurations<TEntity,TKey>
        where TKey : IEquatable<TKey>
        where TEntity : BaseAuditableEntity<TKey>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);

            //builder.Property(p => p.LastModifiedOn).HasComputedColumnSql("GETUTCDATE()");
            //builder.Property(p => p.CreatedOn).HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
