using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class CartDetailConfiguration : IEntityTypeConfiguration<CartDetail>
    {
        public void Configure(EntityTypeBuilder<CartDetail> builder)
        {
            builder.ToTable("CartDetails");
            builder.HasKey(x => x.CartDeltailId);
            builder.Property(x => x.Quantity).IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.CartDetails).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Cart).WithMany(x => x.CartDetails).HasForeignKey(x => x.CartId);
        }
    }
}
