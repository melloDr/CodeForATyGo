using CE.Data.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CE.Data.Extensions
{
   public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                           new AppConfig() { Key = "HomeTitle", Value = "This is home page of RentED system" },
                           new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of RentED system" },
                           new AppConfig() { Key = "HomeDescription", Value = "This is description of RentED system" }
                           );
            // any guid
            var roleId = new string("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new string("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Address = "249 ltt p10",
                Email = "abc@gmail.com",
                NormalizedEmail = "abc@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456"),
                SecurityStamp = string.Empty,
                FullName = "Than Tuan",
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}