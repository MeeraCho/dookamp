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
            .Where(lesson =>  lesson.Id == id && lesson.Status == LessonStatus.Published)
            
            //content
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.LessonContentLanguages)
                    .ThenInclude(contentLanguage => contentLanguage.Language)
            
            //content vocabularies
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.LessonContentVocabularies)
                    .ThenInclude(contentVocabulary => contentVocabulary.Vocabulary)
                        .ThenInclude(vocabulary => vocabulary.VocabularyLanguages)
                            .ThenInclude(vocabularyLanguage => vocabularyLanguage.Language)
            
            //concept check questions
            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.QuizQuestions)
                    .ThenInclude(quizQuestion => quizQuestion.QuizQuestionLanguages)
                        .ThenInclude(quizQuestionLanguage => quizQuestionLanguage.Language)


            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.QuizQuestions)
                    .ThenInclude(quizQuestion => quizQuestion.QuizOptions)
                        .ThenInclude(quizOption => quizOption.QuizOptionLanguages)
                            .ThenInclude(quizOptionLanguage => quizOptionLanguage.Language)

            //lesson-level quiz questions
            .Include(lesson => lesson.QuizQuestions)
                .ThenInclude(quizQuestion => quizQuestion.QuizQuestionLanguages)
                    .ThenInclude(quizQuestionLanguage => quizQuestionLanguage.Language)

            .Include(lesson => lesson.LessonContents)
                .ThenInclude(content => content.QuizQuestions)
                    .ThenInclude(quizQuestion => quizQuestion.QuizOptions)
                        .ThenInclude(quizOption => quizOption.QuizOptionLanguages)
                            .ThenInclude(quizOptionLanguage => quizOptionLanguage.Language)

            //lesson-level quiz questions
            .Include(lesson => lesson.QuizQuestions)
                .ThenInclude(quizQuestion => quizQuestion.QuizQuestionLanguages)
                    .ThenInclude(quizQuestionLanguage => quizQuestionLanguage.Language)
            
            .Include(lesson => lesson.QuizQuestions)
                .ThenInclude(quizQuestion => quizQuestion.QuizOptions)
                    .ThenInclude(quizOption => quizOption.QuizOptionLanguages)  
                        .ThenInclude(quizOptionLanguage => quizOptionLanguage.Language)    


            //asynchronously retrieves the first matching record, or returns null if no record is found
            .FirstOrDefaultAsync(cancellationToken);
    }  
}

