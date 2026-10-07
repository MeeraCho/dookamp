using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuizQuestionAnswerSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuizQuestionAnswers.AnyAsync())
            return;

        var english = await context.Languages
            .SingleAsync(x => x.Code == "en");

        var korean = await context.Languages
            .SingleAsync(x => x.Code == "ko");

        var questions = await context.QuizQuestions
            .Where(x => x.LessonId == 1 && x.LessonContentId != null)
            .OrderBy(x => x.LessonContentId)
            .ToListAsync();

        var answers = new[]
        {
            new QuizQuestionAnswer(questions[0].Id, english.Id, "cell"),
            new QuizQuestionAnswer(questions[0].Id, english.Id, "cells"),
            new QuizQuestionAnswer(questions[0].Id, korean.Id, "세포"),

            new QuizQuestionAnswer(questions[1].Id, english.Id, "parts"),
            new QuizQuestionAnswer(questions[1].Id, english.Id, "part"),
            new QuizQuestionAnswer(questions[1].Id, korean.Id, "부분"),

            new QuizQuestionAnswer(questions[2].Id, english.Id, "job"),
            new QuizQuestionAnswer(questions[2].Id, english.Id, "role"),
            new QuizQuestionAnswer(questions[2].Id, korean.Id, "역할")
        };

        await context.QuizQuestionAnswers.AddRangeAsync(answers);
        await context.SaveChangesAsync();
    }
}