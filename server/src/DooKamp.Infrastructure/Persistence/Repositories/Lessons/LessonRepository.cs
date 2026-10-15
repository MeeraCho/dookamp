using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Domain.Entities.Lessons;
using DooKamp.Domain.Enums;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public sealed class LessonRepository : ILessonRepository
{
    private readonly DooKampDbContext _context;

    public LessonRepository(DooKampDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Lesson>> GetLessonsAsync(
        int locationId,
        int gradeId,
        CancellationToken cancellationToken = default)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(lesson =>
                lesson.Status == LessonStatus.Published &&
                lesson.LessonLocationGrades.Any(
                    lg => lg.LocationId == locationId && lg.GradeId == gradeId))
            .Include(lesson => lesson.LessonTopics)
            .ThenInclude(lessonTopic => lessonTopic.Topic)
            .OrderBy(lesson => lesson.Title)
            .ToListAsync(cancellationToken);
    }
}

