using DooKamp.Application.Features.Topics.GetTopics;
using DooKamp.Application.Features.Topics.GetTopicById;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class TopicsController : ControllerBase
{
    private readonly GetTopicsHandler _getTopicsHandler;
    private readonly GetTopicByIdHandler _getTopicByIdHandler;

    public TopicsController(
        GetTopicsHandler getTopicsHandler,
        GetTopicByIdHandler getTopicByIdHandler)
    {
        _getTopicsHandler = getTopicsHandler;
        _getTopicByIdHandler = getTopicByIdHandler;
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

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTopicById(
        int id,
        CancellationToken cancellationToken)
    {
        var query = new GetTopicByIdQuery(id);

        var topic = await _getTopicByIdHandler.HandleAsync(
            query,
            cancellationToken);

        if (topic is null)
        {
            return NotFound();
        }

        return Ok(topic);
    }
}