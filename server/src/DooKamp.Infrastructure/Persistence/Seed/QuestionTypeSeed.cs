using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class QuestionTypeSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.QuestionTypes.AnyAsync())
            return;

        var questionTypes = new[]
        {
            new QuestionType("SingleChoice"),
            new QuestionType("MultipleChoice"),
            new QuestionType("TrueFalse"),
            new QuestionType("FillBlank"),
            new QuestionType("ShortAnswer"),
            new QuestionType("Matching"),
            new QuestionType("DragDrop"),
            new QuestionType("Ordering")
        };

        await context.QuestionTypes.AddRangeAsync(questionTypes);
        await context.SaveChangesAsync();
    }
}