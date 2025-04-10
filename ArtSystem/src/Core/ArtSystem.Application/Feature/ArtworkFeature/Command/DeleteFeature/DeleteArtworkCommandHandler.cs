
using ArtExhibitionSystem.Application.Exceptions;
using ArtSystem.Application.Contracts.Persistance;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.DeleteFeature
{
    public class DeleteArtworkCommandHandler:IRequestHandler<DeleteArtCommand,bool>
    {
        readonly IArtworksRepository _artworksRepository;
        public DeleteArtworkCommandHandler(IArtworksRepository artworksRepository)
        {
            _artworksRepository=artworksRepository;
        }

        public async Task<bool> Handle(DeleteArtCommand request, CancellationToken cancellationToken)
        {
            var del = await _artworksRepository.DeleteArtwork(request.artworkId);
            if (del==null)
            {
                throw new NotFoundException($"artwork with Id::{request.artworkId} not found");
            }
            return await _artworksRepository.DeleteArtwork(request.artworkId);
        }
    }
}
