using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArtSystem.Persistance.Repositories
{
    public class ArtworksRepository : IArtworksRepository
    {
        readonly ArtDbContext _artDbContext;
        public ArtworksRepository(ArtDbContext artDbContext)
        {
            _artDbContext=artDbContext;
        }


        //getall
        public async Task<IEnumerable<Artworks>> GetAllArtwork()
        {
             return await _artDbContext.Artworks.ToListAsync();
        }

        //add

        public async Task<Artworks> AddArtwork(Artworks artwork)
        {
             await _artDbContext.Artworks.AddAsync(artwork);
            await _artDbContext.SaveChangesAsync();
            return artwork;
        }

        //GetArtworkById

        public async Task<Artworks> GetArtworkById(int artworkId)
        {
            return await _artDbContext.Artworks.FirstOrDefaultAsync(b => b.ArtworkId == artworkId);
        }

        //UpdateArtworkAsync
        public async Task<Artworks> UpdateArtwork(int artworkId,Artworks artwork )
        {
            var getArt = await GetArtworkById(artwork.ArtworkId);
            _artDbContext.Artworks.Update(artwork);
            await _artDbContext.SaveChangesAsync();
            return getArt;
        }

        //DeleteArtwork
        public async Task<bool> DeleteArtwork(int artworkId)
        {
            var delart = await GetArtworkById(artworkId);
            if (delart is not null)
            {
                _artDbContext.Artworks.Remove(delart);
                return await _artDbContext.SaveChangesAsync() > 0;
            }
            return true;
        }

       

    }
}
