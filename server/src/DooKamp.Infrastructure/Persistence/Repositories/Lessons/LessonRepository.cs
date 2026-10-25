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
        int? locationId,
        int? gradeId,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Lessons
            .Include(lesson => lesson.LessonTopics)
                .ThenInclude(lessonTopic => lessonTopic.Topic)
            .AsQueryable();

        if (locationId.HasValue)
        {
            query = query.Where(lesson => 
                lesson.LessonLocationGrades.Any(lg => lg.LocationId == locationId.Value));
        }

        if (gradeId.HasValue)
        {
            query = query.Where(lesson => 
                lesson.LessonLocationGrades.Any(lg => lg.GradeId == gradeId.Value));
        }

        return await query
            .Include(lesson => lesson.LessonTopics)
                .ThenInclude(lessonTopic => lessonTopic.Topic)
            .OrderBy(lesson => lesson.Title)
            .ToListAsync(cancellationToken);
    }

    
}

