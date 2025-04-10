using ArtSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArtSystem.Persistance.Configuration
{
    public class ArtworkConfiguration : IEntityTypeConfiguration<Artworks>
    {
        public void Configure(EntityTypeBuilder<Artworks> builder)
        {
            builder.HasData(
                new Artworks
                {
                    ArtworkId = 1,
                    Title = "Painting",
                    CreationDate = new DateTime(2024, 1, 1),
                    Description = "horse Painting",
                    ImageURL = "https://th.bing.com/th/id/OIP.aijJ8cc0jZng8oCWTiA1gQHaKT?w=146&h=180&c=7&r=0&o=5&pid=1.7"
                });
        }
    }
}
