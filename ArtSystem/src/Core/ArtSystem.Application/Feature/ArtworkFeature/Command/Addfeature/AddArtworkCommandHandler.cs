using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.Addfeature
{
    public class AddArtworkCommandHandler:IRequestHandler<AddArtworkCommand,ArtworksDto>
    {
        readonly IArtworksRepository _artworksRepository;
        readonly IMapper _mapper;
        public AddArtworkCommandHandler(IArtworksRepository artworksRepository, IMapper mapper)
        {
            _artworksRepository = artworksRepository;
            _mapper = mapper;
        }

        public async  Task<ArtworksDto> Handle(AddArtworkCommand request, CancellationToken cancellationToken)
        {

            var artwork=new  Artworks();
            _mapper.Map(request.artworkdto,artwork);
            var result= await _artworksRepository.AddArtwork(artwork);
            return request.artworkdto;
        }
    }
}
