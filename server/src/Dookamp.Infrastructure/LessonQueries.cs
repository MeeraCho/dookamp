using Dookamp.Application.Lessons;
using Microsoft.EntityFrameworkCore;

namespace Dookamp.Infrastructure;

public sealed class EfLessonQueries(LessonDbContext db) : ILessonQueries
{
    public async Task<LessonDetails?> GetByIdAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default)
    {
        var lesson = await db.Lessons
            .AsNoTracking()
            .Where(x => x.Id == lessonId)
            .Select(x => new
            {
                x.Id,
                x.TopicId,
                Language = x.Languages
                    .OrderByDescending(language => language.LanguageId == languageId)
                    .ThenByDescending(language => language.LanguageId == 1)
                    .Select(language => new { language.Name, language.Description })
                    .FirstOrDefault(),
                Contents = x.Contents
                    .OrderBy(content => content.SortOrder)
                    .Select(content => new
                    {
                        content.Id,
                        content.SortOrder,
                        Text = content.Languages
                            .Where(language => language.LanguageId == languageId)
                            .Select(language => language.Text)
                            .FirstOrDefault()
                    })
                    .ToList(),
                Questions = x.Questions
                    .OrderBy(question => question.SortOrder)
                    .Select(question => new
                    {
                        question.Id,
                        question.QuestionTypeId,
                        question.SortOrder,
                        QuestionText = question.Languages
                            .Where(language => language.LanguageId == languageId)
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
                                    .Where(language => language.LanguageId == languageId)
                                    .Select(language => language.Text)
                                    .FirstOrDefault()
                            })
                            .ToList()
                    })
                    .ToList()
            })
            .FirstOrDefaultAsync(cancellationToken);

        if (lesson is null || lesson.Language is null)
        {
            return null;
        }

        return new LessonDetails(
            lesson.Id,
            lesson.TopicId,
            lesson.Language.Name,
            lesson.Language.Description,
            lesson.Contents
                .Where(content => content.Text is not null)
                .Select(content => new LessonContentDetails(
                    content.Id,
                    content.SortOrder,
                    content.Text!))
                .ToList(),
            lesson.Questions
                .Where(question => question.QuestionText is not null)
                .Select(question => new QuizQuestionDetails(
                    question.Id,
                    question.QuestionTypeId,
                    question.SortOrder,
                    question.QuestionText!,
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
