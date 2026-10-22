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

    public async Task<Lesson?> GetLessonByIdAsync(
        int id,
        CancellationToken cancellationToken = default)
    {
        return await _context.Lessons
            .AsNoTracking()
            .Where(lesson => lesson.Status == LessonStatus.Published)

            // Lesson Contents
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.Languages)
                    .ThenInclude(language => language.Language)

            // Vocabularies
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.Vocabularies)
                    .ThenInclude(contentVocabulary => contentVocabulary.Vocabulary)
                        .ThenInclude(vocabulary => vocabulary.Languages)
                            .ThenInclude(language => language.Language)

            // Concept Check Questions
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.QuizQuestions)
                    .ThenInclude(question => question.Languages)
                        .ThenInclude(language => language.Language)

            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.QuizQuestions)
                    .ThenInclude(question => question.Options)
                        .ThenInclude(option => option.Languages)
                            .ThenInclude(language => language.Language)

            // Lesson-level Quiz Questions
            .Include(lesson => lesson.QuizQuestions)
                .ThenInclude(question => question.Languages)
                    .ThenInclude(language => language.Language)

            .Include(lesson => lesson.QuizQuestions)
                .ThenInclude(question => question.Options)
                    .ThenInclude(option => option.Languages)
                        .ThenInclude(language => language.Language)

            .FirstOrDefaultAsync(
                lesson => lesson.Id == id,
                cancellationToken);
    }  
}

