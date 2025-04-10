using MediatR;

namespace ArtSystem.Application.Feature.ArtworkFeature.Command.DeleteFeature
{
    public record DeleteArtCommand(int artworkId):IRequest<bool>;
}
