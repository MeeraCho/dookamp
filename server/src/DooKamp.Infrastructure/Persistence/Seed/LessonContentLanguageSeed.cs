using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonContentLanguageSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.LessonContentLanguages.AnyAsync())
            return;

        var english = await context.Languages
            .SingleAsync(x => x.Code == "en");

        var korean = await context.Languages
            .SingleAsync(x => x.Code == "ko");

        var lessonContents = await context.LessonContents
            .Where(x => x.LessonId == 1)
            .OrderBy(x => x.Order)
            .ToListAsync();

        var lessonContentLanguages = new[]
        {
            new LessonContentLanguage(lessonContents[0].Id, english.Id, "A cell is the basic unit of all living things."),
            new LessonContentLanguage(lessonContents[0].Id, korean.Id, "세포는 모든 생물을 이루는 기본 단위이다."),
            new LessonContentLanguage(lessonContents[1].Id, english.Id, "Cells have different parts that help them stay alive and work properly."),
            new LessonContentLanguage(lessonContents[1].Id, korean.Id, "세포에는 생존하고 제대로 기능하도록 돕는 여러 부분이 있다."),
            new LessonContentLanguage(lessonContents[2].Id, english.Id, "Each part of a cell has a different job, and the parts work together."),
            new LessonContentLanguage(lessonContents[2].Id, korean.Id, "세포의 각 부분은 서로 다른 역할을 하며 함께 작동한다."),
        };

        await context.LessonContentLanguages
            .AddRangeAsync(lessonContentLanguages);

        await context.SaveChangesAsync();
    }
}