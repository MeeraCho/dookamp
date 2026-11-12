using DooKamp.Application.DTOs.Grades;
using DooKamp.Application.Interfaces.Grades;

namespace DooKamp.Application.Features.Grades.GetGrades;

public sealed class GetGradesHandler(IGradeRepository gradeRepository)
{
    public async Task<IReadOnlyList<GradeListDto>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var grades = await gradeRepository.GetGradesAsync(cancellationToken);

        return grades.Select(grade => new GradeListDto
        {
            Id = grade.Id,
            Name = grade.Name
        }).ToList();
    }
}