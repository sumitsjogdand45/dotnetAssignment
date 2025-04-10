using ArtSystem.Application.DTOs;
using ArtSystem.Application.Feature.ArtworkFeature.Command.Addfeature;
using ArtSystem.Application.Feature.ArtworkFeature.Command.DeleteFeature;
using ArtSystem.Application.Feature.ArtworkFeature.Command.UpdateFeature;
using ArtSystem.Application.Feature.ArtworkFeature.Query.GetAllFeature;
using ArtSystem.Application.Feature.ArtworkFeature.Query.GetbyIdFeature;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArtSystem.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ArtworkController : ControllerBase
    {
        readonly IMediator _mediatoR;
        //readonly ILogger<ArtworkController> _logger;
        readonly ILogger _logger;
        public ArtworkController(IMediator mediator, ILogger<ArtworkController> logger)
        {
            _mediatoR = mediator;
            _logger = logger;
        }

        //getallartwork

        [HttpGet]
        public async Task<IActionResult> GetAllArtwork()
        {
            _logger.LogInformation("GetAllArtwork initiated successfully");
            var addart = await _mediatoR.Send(new GetAllArtworkQuery());
            return Ok(addart);
        }


        //AddArtwork

        [HttpPost]
        public async Task<IActionResult> AddArtwork(ArtworksDto artworkdto)
        {
            _logger.LogInformation("AddArtwork method initiated successfully");
            var result = await _mediatoR.Send(new AddArtworkCommand(artworkdto));
            return Ok(result);
        }

        //GetArtworkById

        [HttpGet("{artworkId}")]
        public async Task<IActionResult> GetArtworkById(int artworkId)
        {
            _logger.LogInformation("GetArtworkById method initiated successfully");
            var result = await _mediatoR.Send(new GetArtworkByIdQuery(artworkId));
            return Ok(result);
        }

        //UpdateArtwork
        [HttpPut]
        public async Task<IActionResult> UpdateArtwork(int artworkId, ArtworksDto artworksdto)
        {
            _logger.LogInformation("UpdateArtwork method initiated successfully");
            var result = await _mediatoR.Send(new UpdateArtworkCommand(artworkId, artworksdto));
            return Ok(result);
        }

        //deleteArtwork
        [HttpDelete]
        public async Task<IActionResult> DeleteArtwork(int artworkId)
        {
            _logger.LogInformation("DeleteArtwork method initiated successfully");
            var result = await _mediatoR.Send(new DeleteArtCommand(artworkId));
            return Ok(result);
        }

    }
}
