using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuizQuestionLanguageSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuizQuestionLanguages.AnyAsync())
            return;

        var english = await context.Languages
            .SingleAsync(x => x.Code == "en");

        var korean = await context.Languages
            .SingleAsync(x => x.Code == "ko");

        var contentQuestions = await context.QuizQuestions
            .Where(x => x.LessonId == 1 && x.LessonContentId != null)
            .OrderBy(x => x.LessonContentId)
            .ToListAsync();

        var lessonQuestion = await context.QuizQuestions
            .SingleAsync(x => x.LessonId == 1 && x.LessonContentId == null);

        var questionLanguages = new[]
        {
            new QuizQuestionLanguage(contentQuestions[0].Id, english.Id, "A _____ is the basic unit of all living things."),
            new QuizQuestionLanguage(contentQuestions[0].Id, korean.Id, "_____는 모든 생물을 이루는 기본 단위이다."),

            new QuizQuestionLanguage(contentQuestions[1].Id, english.Id, "Cells have different _____ that help them stay alive and work properly."),
            new QuizQuestionLanguage(contentQuestions[1].Id, korean.Id, "세포에는 생존하고 제대로 기능하도록 돕는 여러 _____이 있다."),

            new QuizQuestionLanguage(contentQuestions[2].Id, english.Id, "Each part of a cell has a different _____."),
            new QuizQuestionLanguage(contentQuestions[2].Id, korean.Id, "세포의 각 부분은 서로 다른 _____을 한다."),

            new QuizQuestionLanguage(lessonQuestion.Id, english.Id, "A cell is the basic unit of all living things."),
            new QuizQuestionLanguage(lessonQuestion.Id, korean.Id, "세포는 모든 생물을 이루는 기본 단위이다.")
        };

        await context.QuizQuestionLanguages.AddRangeAsync(questionLanguages);
        await context.SaveChangesAsync();
    }
}