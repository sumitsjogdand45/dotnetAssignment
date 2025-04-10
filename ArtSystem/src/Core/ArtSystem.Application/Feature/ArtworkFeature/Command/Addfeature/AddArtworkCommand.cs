using ArtSystem.Application.DTOs;
using ArtSystem.Domain.Entities;
using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.Addfeature
{
    public record AddArtworkCommand(ArtworksDto artworkdto):IRequest<ArtworksDto>;
    
}
