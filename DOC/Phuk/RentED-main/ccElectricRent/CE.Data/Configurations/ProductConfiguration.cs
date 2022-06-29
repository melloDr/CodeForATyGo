using CE.Data.Entity;
using CE.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductId).UseIdentityColumn();
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.ThumbNail).IsRequired();
            builder.Property(x => x.Status).HasDefaultValue(ProductStatus.Stock);
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
        }
    }
}
