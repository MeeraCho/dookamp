using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Application.Interfaces.Topics;

public interface ITopicRepository
{
    Task<IReadOnlyList<Topic>> GetTopicsAsync(
        int? subjectId,
        int? locationId,
        int? gradeId,
        int? parentTopicId,
        CancellationToken cancellationToken = default);

    Task<Topic?> GetTopicByIdAsync(
        int id,
        CancellationToken cancellationToken = default);
}