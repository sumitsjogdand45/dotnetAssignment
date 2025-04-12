using System;
using ArtSystem.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSystem.Identity.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                 new ApplicationUser
                 {
                     Id = "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                     Email = "admin@gmail.com",
                     NormalizedEmail = "ADMIN@GMAIL.COM",
                     FirstName = "Admin",
                     LastName = "System",
                     UserName = "admin@gmail.com",
                     NormalizedUserName = "admin@gmail.com",
                     PasswordHash = hasher.HashPassword(null, "Admin@123")
                 },
                new ApplicationUser()
                {
                    Id = "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                    Email = "sunny@gmail.com",
                    NormalizedEmail = "SUNNY@GMAIL.COM",
                    FirstName = "sunny",
                    LastName = "Jadhav",
                    NormalizedUserName = "sunny@gmail.com",
                    UserName = "sunny@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "Sunny@123")
                });
        }
    }
}
