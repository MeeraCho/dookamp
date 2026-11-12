using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Application.Interfaces.Subjects;

public interface ISubjectRepository
{
    Task<IReadOnlyList<Subject>> GetSubjectsAsync(
        int? locationId,
        int? gradeId,
        CancellationToken cancellationToken = default);
}