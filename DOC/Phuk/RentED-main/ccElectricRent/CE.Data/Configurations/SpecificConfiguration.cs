using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
  public class SpecificConfiguration : IEntityTypeConfiguration<Specific>
    {
        public void Configure(EntityTypeBuilder<Specific> builder)
        {
            builder.ToTable("Specifics");
            builder.HasKey(x => x.SpecId);
            builder.Property(x => x.SpecId).UseIdentityColumn();
            builder.Property(x => x.ProductKey);
            builder.Property(x => x.Value);
            builder.HasOne(x => x.Product).WithMany(x => x.Specifics).HasForeignKey(x => x.ProductId);
        }
    }
}
