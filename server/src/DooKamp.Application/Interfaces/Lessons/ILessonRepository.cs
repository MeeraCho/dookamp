using DooKamp.Domain.Entities.Lessons;

namespace DooKamp.Application.Interfaces.Lessons;

public interface ILessonRepository
{
    Task<IReadOnlyList<Lesson>> GetLessonsAsync(
        CancellationToken cancellationToken = default);

    Task<Lesson?> GetLessonByIdAsync(
        int id,
        CancellationToken cancellationToken = default);
}