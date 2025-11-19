using Company.Talabat.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Talabat.Infrastructure.Persistence.Data.Config.Products
{
    internal class ProductCategoryConfigurations : BaseAuditableEntityConfigurations<ProductCategory,int>
    {
        public override void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();
        }
    }
}
