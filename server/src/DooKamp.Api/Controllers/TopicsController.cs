using DooKamp.Application.Features.Topics.GetTopics;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TopicsController : ControllerBase
{
    private readonly GetTopicsHandler _getTopicsHandler;

    public TopicsController(GetTopicsHandler getTopicsHandler)
    {
        _getTopicsHandler = getTopicsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetTopics(
        [FromQuery] int? subjectId,
        [FromQuery] int? locationId,
        [FromQuery] int? gradeId,
        [FromQuery] int? parentTopicId,
        CancellationToken cancellationToken)
    {
        var query = new GetTopicsQuery(
            subjectId,
            locationId,
            gradeId,
            parentTopicId);

        var topics = await _getTopicsHandler.HandleAsync(
            query,
            cancellationToken);

        return Ok(topics);
    }
}