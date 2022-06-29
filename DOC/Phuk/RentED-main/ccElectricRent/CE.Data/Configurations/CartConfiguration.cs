using CE.Data.Entity;
using CE.Data.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");
            builder.HasKey(x =>  x.CartId);
            builder.Property(x => x.CartId).UseIdentityColumn();
            builder.Property(x => x.Status).HasDefaultValue(CartStatus.active);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Carts).HasForeignKey(x => x.UserId);
        }
    }
}
