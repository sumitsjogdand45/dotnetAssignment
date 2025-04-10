using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.UpdateFeature
{
    public record UpdateArtworkCommand( int artworkId,ArtworksDto artworksdto) :IRequest<ArtworksDto>;
    
}
