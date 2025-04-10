
using ArtExhibitionSystem.Application.Exceptions;
using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.UpdateFeature
{
    public class UpdateArtworkCommandHandler:IRequestHandler<UpdateArtworkCommand,ArtworksDto>
    {
        readonly IArtworksRepository _artworksRepository;
        readonly IMapper _mapper;
        public UpdateArtworkCommandHandler(IArtworksRepository artworksRepository, IMapper mapper)
        {
            _artworksRepository=artworksRepository;
            _mapper = mapper;
        }

        public async Task<ArtworksDto> Handle(UpdateArtworkCommand request, CancellationToken cancellationToken)
        {
            var updateart = await _artworksRepository.GetArtworkById(request.artworkId);
            if (updateart == null)
            {
                throw new NotFoundException($"artwork with id {request.artworkId} not found");
            }
            _mapper.Map(request.artworksdto, updateart);
            var updatedart = await _artworksRepository.UpdateArtwork(request.artworkId,updateart);
            return request.artworksdto;


            //return updateart;
        }
    }
}
