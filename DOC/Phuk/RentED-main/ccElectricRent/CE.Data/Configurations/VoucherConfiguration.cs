using CE.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Configurations
{
    public class VoucherConfiguration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable("Vouchers");
            builder.HasKey(x => x.VoucherId);
            builder.Property(x => x.VoucherId).UseIdentityColumn();
            builder.Property(x => x.SaleOff).IsRequired();
            builder.Property(x => x.StartDate).HasColumnType("date");
            builder.Property(x => x.FinishDate).HasColumnType("date");
        }
    }
}
