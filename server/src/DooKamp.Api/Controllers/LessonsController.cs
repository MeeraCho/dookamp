using DooKamp.Application.DTOs.Lessons;
using DooKamp.Application.Features.Lessons.GetLesson;
using DooKamp.Application.Features.Lessons.GetLessons;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class LessonsController : ControllerBase
{
    private readonly GetLessonsHandler _getLessonsHandler;
    private readonly GetLessonHandler _getLessonHandler;

    public LessonsController(
        GetLessonsHandler getLessonsHandler,
        GetLessonHandler getLessonHandler)
    {
        _getLessonsHandler = getLessonsHandler;
        _getLessonHandler = getLessonHandler;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetLessons(
        [FromQuery] int? locationId,
        [FromQuery] int? gradeId,
        CancellationToken cancellationToken)
    {
        var query = new GetLessonsQuery(locationId, gradeId);

        var lessons = await _getLessonsHandler.HandleAsync(
            query,
            cancellationToken);

        return Ok(lessons);		    
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<LessonDetailDto>> GetLesson(
        int id,
        CancellationToken cancellationToken)
    {
        var query = new GetLessonQuery(id);

        var lesson = await _getLessonHandler.HandleAsync(
            query,
            cancellationToken);

        return Ok(lesson);
    }
}