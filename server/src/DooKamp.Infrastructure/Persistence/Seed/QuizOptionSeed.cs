using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuizOptionSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuizOptions.AnyAsync())
            return;

        var lessonQuestion = await context.QuizQuestions
            .SingleAsync(x => x.LessonId == 1 && x.LessonContentId == null);

        var options = new[]
        {
            new QuizOption(lessonQuestion.Id, true, 1), //1이면 정답 
            new QuizOption(lessonQuestion.Id, false, 2)
        };

        await context.QuizOptions.AddRangeAsync(options);
        await context.SaveChangesAsync();
    }
}