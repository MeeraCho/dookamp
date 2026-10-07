using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuizQuestionSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuizQuestions.AnyAsync())
            return;

        var lesson = await context.Lessons
            .SingleAsync(x => x.Id == 1);

        var lessonContents = await context.LessonContents
            .Where(x => x.LessonId == lesson.Id)
            .OrderBy(x => x.Order)
            .ToListAsync();

        var fillBlank = await context.QuestionTypes
            .SingleAsync(x => x.Name == "FillBlank");

        var trueFalse = await context.QuestionTypes
            .SingleAsync(x => x.Name == "TrueFalse");

        var questions = new[]
        {
            new QuizQuestion(lesson.Id, lessonContents[0].Id, fillBlank.Id, 1),
            new QuizQuestion(lesson.Id, lessonContents[1].Id, fillBlank.Id, 2),
            new QuizQuestion(lesson.Id, lessonContents[2].Id, fillBlank.Id, 3),
            new QuizQuestion(lesson.Id, null, trueFalse.Id, 1)
        };

        await context.QuizQuestions.AddRangeAsync(questions);
        await context.SaveChangesAsync();
    }
}