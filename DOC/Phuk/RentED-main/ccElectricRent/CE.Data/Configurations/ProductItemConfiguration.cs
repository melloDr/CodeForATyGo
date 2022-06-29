using CE.Data.Entity;
using CE.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder.ToTable("ProductItems");
            builder.HasKey(x => x.PrlItemId );
            builder.Property(x => x.PrlItemId).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(ProductItemStatus.waiting);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductItems).HasForeignKey(x => x.ProductId);
        }
    }
}
