
using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Query.GetbyIdFeature
{
    public class GetArtworkByIdQueryHandler : IRequestHandler<GetArtworkByIdQuery, ArtworksDto>
    {
        readonly IArtworksRepository _artworksRepository;
        readonly IMapper _mapper;

        public GetArtworkByIdQueryHandler(IArtworksRepository artworksRepository, IMapper mapper)
        {
            _artworksRepository = artworksRepository;
            _mapper=mapper;
        }

        public async Task<ArtworksDto> Handle(GetArtworkByIdQuery request, CancellationToken cancellationToken)
        {
            var updateart = await _artworksRepository.GetArtworkById(request.artworkid);
            var uptodate=_mapper.Map<ArtworksDto>(updateart);
            return uptodate;
        }
    }
}
