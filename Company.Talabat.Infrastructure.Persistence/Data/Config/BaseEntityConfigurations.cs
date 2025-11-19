using Company.Talabat.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.Talabat.Infrastructure.Persistence.Data.Config
{
    public class BaseEntityConfigurations<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
            where TKey : IEquatable<TKey>
            where TEntity : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);

            // the value will be generated on add based on the type of TKey
            builder.Property(e => e.Id).ValueGeneratedOnAdd();
        }
    }
}
