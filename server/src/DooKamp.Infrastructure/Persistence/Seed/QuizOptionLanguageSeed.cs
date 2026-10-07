using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuizOptionLanguageSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuizOptionLanguages.AnyAsync())
            return;

        var english = await context.Languages
            .SingleAsync(x => x.Code == "en");

        var korean = await context.Languages
            .SingleAsync(x => x.Code == "ko");

        var lessonQuestion = await context.QuizQuestions
            .SingleAsync(x => x.LessonId == 1 && x.LessonContentId == null);

        var options = await context.QuizOptions
            .Where(x => x.QuizQuestionId == lessonQuestion.Id)
            .OrderBy(x => x.Order)
            .ToListAsync();

        var optionLanguages = new[]
        {
            new QuizOptionLanguage(options[0].Id, english.Id, "True"),
            new QuizOptionLanguage(options[0].Id, korean.Id, "맞다"),
            new QuizOptionLanguage(options[1].Id, english.Id, "False"),
            new QuizOptionLanguage(options[1].Id, korean.Id, "아니다")
        };

        await context.QuizOptionLanguages.AddRangeAsync(optionLanguages);
        await context.SaveChangesAsync();
    }
}