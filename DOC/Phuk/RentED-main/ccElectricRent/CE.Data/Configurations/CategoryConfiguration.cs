using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryId).UseIdentityColumn();
            builder.Property(x => x.CategoryName).IsRequired();
            builder.Property(x => x.Thumbnail).IsRequired();
        }
    }
}
