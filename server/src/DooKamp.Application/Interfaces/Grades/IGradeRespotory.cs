using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Application.Interfaces.Grades;

public interface IGradeRepository
{
    Task<IReadOnlyList<Grade>> GetGradesAsync(
        CancellationToken cancellationToken = default);
}