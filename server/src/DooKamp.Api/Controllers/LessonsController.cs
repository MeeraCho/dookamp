using DooKamp.Application.Features.Lessons.GetLessons;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class LessonsController : ControllerBase
{
    private readonly GetLessonsHandler _getLessonsHandler;

    public LessonsController(GetLessonsHandler getLessonsHandler)
    {
        _getLessonsHandler = getLessonsHandler;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetLessons(
        [FromQuery] int? locationId,
        [FromQuery] int? gradeId)
    {
        var query = new GetLessonsQuery(locationId, gradeId);

        var lessons = await _getLessonsHandler.HandleAsync(query);

        return Ok(lessons);		    
    }
}