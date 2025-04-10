using ArtSystem.Application.Contracts.Persistance;
using ArtSystem.Application.DTOs;
using AutoMapper;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Query.GetAllFeature
{


    public class GetAllArtworkQueryHandler : IRequestHandler<GetAllArtworkQuery, IEnumerable<ArtworksDto>>
    {
        readonly IArtworksRepository _artworksRepository;
        readonly IMapper _mapper;
        public GetAllArtworkQueryHandler(IArtworksRepository artworksRepository, IMapper mapper)
        {
            _artworksRepository = artworksRepository;
            _mapper= mapper;
        }

        public async Task<IEnumerable<ArtworksDto>> Handle(GetAllArtworkQuery request, CancellationToken cancellationToken)
        {
            var arts= await _artworksRepository.GetAllArtwork();
            var allarts = _mapper.Map<IEnumerable<ArtworksDto>>(arts);
            return allarts;
        }
    }
}
