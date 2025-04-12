﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArtSystem.Identity.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSystem.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        //public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        //{
          
        //}

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData
        (
            new IdentityRole
            {
                Id = "41886008 - 6086 - 1fbf - b923 - 2879a6680b9a",
                Name = "User",
                NormalizedName = "USER"
            },
            new IdentityRole
            {
                Id = "41776008 - 6086 - 1fbf - b923 - 2879a6680b9a",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            }
        );
        }
    }
}
