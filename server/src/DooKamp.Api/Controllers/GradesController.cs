using DooKamp.Application.Features.Grades.GetGrades;
using DooKamp.Application.DTOs.Grades;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class GradesController(GetGradesHandler handler) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<GradeListDto>>> GetGrades(
        CancellationToken cancellationToken)
    {
        var grades = await handler.HandleAsync(cancellationToken);

        return Ok(grades);
    }
}