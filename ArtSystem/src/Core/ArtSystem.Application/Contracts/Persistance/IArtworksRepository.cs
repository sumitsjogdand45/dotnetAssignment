
using ArtSystem.Domain.Entities;

namespace ArtSystem.Application.Contracts.Persistance
{
    public interface IArtworksRepository
    {
        Task<IEnumerable<Artworks>> GetAllArtwork();
        Task<Artworks> AddArtwork(Artworks artwork);
        Task<Artworks>GetArtworkById(int artworkId);
        Task<Artworks> UpdateArtwork(int artworkId, Artworks artwork);
        Task<bool> DeleteArtwork(int artworkId);
    }
}
