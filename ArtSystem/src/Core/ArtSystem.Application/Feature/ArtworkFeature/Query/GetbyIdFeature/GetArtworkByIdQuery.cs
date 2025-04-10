using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Query.GetbyIdFeature
{
    public record GetArtworkByIdQuery(int artworkid):IRequest<ArtworksDto>;
 
}
