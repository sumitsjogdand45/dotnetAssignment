using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Query.GetAllFeature
{
    public record GetAllArtworkQuery() : IRequest<IEnumerable<ArtworksDto>>;

}
