using Dookamp.Application.Quiz;
using Microsoft.EntityFrameworkCore;

namespace Dookamp.Infrastructure;

public sealed class EfQuizQueries(LessonDbContext db) : IQuizQueries
{
    public async Task<QuizDetails?> GetForLessonAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default)
    {
        var lessonExists = await db.Lessons
            .AsNoTracking()
            .AnyAsync(lesson => lesson.Id == lessonId, cancellationToken);

        if (!lessonExists)
        {
            return null;
        }

        var questions = await db.QuizQuestions
            .AsNoTracking()
            .Where(question => question.LessonId == lessonId)
            .OrderBy(question => question.SortOrder)
            .Select(question => new
            {
                question.Id,
                question.QuestionTypeId,
                question.SortOrder,
                Text = question.Languages
                    .OrderByDescending(language => language.LanguageId == languageId)
                    .ThenByDescending(language => language.LanguageId == 1)
                    .Select(language => language.QuestionText)
                    .FirstOrDefault(),
                Options = question.Options
                    .OrderBy(option => option.SortOrder)
                    .Select(option => new
                    {
                        option.Id,
                        option.SortOrder,
                        option.IsCorrect,
                        Text = option.Languages
                            .OrderByDescending(language => language.LanguageId == languageId)
                            .ThenByDescending(language => language.LanguageId == 1)
                            .Select(language => language.Text)
                            .FirstOrDefault()
                    })
                    .ToList()
            })
            .ToListAsync(cancellationToken);

        return new QuizDetails(
            lessonId,
            questions
                .Where(question => question.Text is not null)
                .Select(question => new QuizQuestionDetails(
                    question.Id,
                    question.QuestionTypeId,
                    question.SortOrder,
                    question.Text!,
                    question.Options
                        .Where(option => option.Text is not null)
                        .Select(option => new QuizOptionDetails(
                            option.Id,
                            option.SortOrder,
                            option.IsCorrect,
                            option.Text!))
                        .ToList()))
                .ToList());
    }
}
