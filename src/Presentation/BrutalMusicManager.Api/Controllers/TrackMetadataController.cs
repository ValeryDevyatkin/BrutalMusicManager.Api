using BrutalMusicManager.Api.Application.Features.TrackMetadata;
using BrutalMusicManager.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace BrutalMusicManager.Api.Controllers;

public class TrackMetadataController : ApiControllerBase
{
    private readonly TrackMetadataService _trackMetadataService;

    public TrackMetadataController(
        ILogger<TrackMetadataController> logger,
        TrackMetadataService trackMetadataService) : base(logger)
    {
        _trackMetadataService = trackMetadataService;
    }

    [HttpGet(Name = "Get Track Metadata Items")]
    public async Task<ActionResult<IEnumerable<TrackMetadataDto>>> Get()
    {
        try
        {
            var items = await _trackMetadataService.GetAllAsync();

            return Ok(items);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }
}