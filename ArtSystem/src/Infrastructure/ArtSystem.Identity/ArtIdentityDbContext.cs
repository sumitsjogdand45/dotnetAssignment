using ArtSystem.Identity.Configuration;
using ArtSystem.Identity.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtSystem.Identity
{
    public class ArtIdentityDbContext:IdentityDbContext<ApplicationUser>
    {
        public ArtIdentityDbContext(DbContextOptions<ArtIdentityDbContext>options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new UserRoleConfiguration());
        }
        
    }
}
