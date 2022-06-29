using CE.Data.Configurations;
using CE.Data.Entity;
using CE.Data.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.EF
{
    public class CeDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        
        public CeDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ////Configure using Fluent API
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartDetailConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
            modelBuilder.ApplyConfiguration(new ImageProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new VoucherConfiguration());
            modelBuilder.ApplyConfiguration(new SpecificConfiguration());



            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());

            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AppUserRoles").HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AppEmpLogins").HasKey(x => x.UserId);
            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AppEmpTokens").HasKey(x => x.UserId);

            modelBuilder.Seed();
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public DbSet<ImageProduct> ImageProducts { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Specific> Specifics { get; set; }
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}