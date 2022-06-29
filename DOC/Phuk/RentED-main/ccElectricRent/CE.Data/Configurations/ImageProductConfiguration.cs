using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class ImageProductConfiguration : IEntityTypeConfiguration<ImageProduct>
    {
        public void Configure(EntityTypeBuilder<ImageProduct> builder)
        {
            builder.ToTable("ImageProducts");
            builder.HasKey(x => x.ImageId);
            builder.Property(x => x.ImageId).UseIdentityColumn();
            builder.Property(x => x.Url).IsRequired();
            builder.HasOne(x => x.ProductItem).WithMany(x => x.ImageProducts).HasForeignKey(x => x.PrlItemId);
        }
    }
}
