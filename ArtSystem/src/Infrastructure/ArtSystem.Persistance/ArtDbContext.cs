using ArtSystem.Domain.Entities;
using ArtSystem.Identity.Model;
using ArtSystem.Persistance.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ArtSystem.Persistance
{
    public class ArtDbContext:DbContext
    {
        public ArtDbContext(DbContextOptions<ArtDbContext> options) : base(options)
        {
            
        }
        public DbSet<Artworks> Artworks { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtworkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
