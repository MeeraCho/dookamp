
using DooKamp.Application.Features.Subjects.GetSubjects;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class SubjectsController : ControllerBase
{
    private readonly GetSubjectsHandler _getSubjectsHandler;

    public SubjectsController(GetSubjectsHandler getSubjectsHandler)
    {
        _getSubjectsHandler = getSubjectsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetSubjects(
        [FromQuery] int? locationId,
        [FromQuery] int? gradeId,
        CancellationToken cancellationToken)
    {
        var query = new GetSubjectsQuery(locationId, gradeId);

        var subjects = await _getSubjectsHandler.HandleAsync(
            query,
            cancellationToken);

        return Ok(subjects);
    }
}
