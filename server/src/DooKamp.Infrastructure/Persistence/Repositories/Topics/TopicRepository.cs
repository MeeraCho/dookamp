using DooKamp.Application.Interfaces.Topics;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public sealed class TopicRepository : ITopicRepository
{
    private readonly DooKampDbContext _context;

    public TopicRepository(DooKampDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Topic>> GetTopicsAsync(
        int? subjectId,
        int? locationId,
        int? gradeId,
        int? parentTopicId,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Topics
            .AsNoTracking()
            .AsQueryable();

        if (subjectId.HasValue)
        {
            query = query.Where(topic =>
                topic.SubjectId == subjectId.Value);
        }

        if (locationId.HasValue || gradeId.HasValue)
        {
            query = query.Where(topic =>
                topic.TopicLocationGrades.Any(topicLocationGrade =>
                    (!locationId.HasValue ||
                        topicLocationGrade.LocationId == locationId.Value)
                    &&
                    (!gradeId.HasValue ||
                        topicLocationGrade.GradeId == gradeId.Value)
                )
            );
        }

        if (parentTopicId.HasValue)
        {
            query = query.Where(topic =>
                topic.ParentTopicId == parentTopicId.Value);
        }

        return await query
            .OrderBy(topic => topic.Name)
            .ToListAsync(cancellationToken);
    }

    public async Task<Topic?> GetTopicByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Topics
            .AsNoTracking()
            .Include(topic => topic.ChildTopics)
            .Include(topic => topic.TopicLessons)
                .ThenInclude(topicLesson => topicLesson.Lesson)
            .FirstOrDefaultAsync(
                topic => topic.Id == id,
                cancellationToken);
    }
}