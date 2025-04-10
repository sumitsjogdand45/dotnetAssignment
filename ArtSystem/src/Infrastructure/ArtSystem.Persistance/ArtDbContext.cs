using ArtSystem.Domain.Entities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtworkConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
