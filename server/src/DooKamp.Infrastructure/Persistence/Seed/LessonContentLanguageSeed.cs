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
            .OrderBy(x => x.Id)
            .ToListAsync();

        var lessonContentLanguages = new List<LessonContentLanguage>();

        foreach (var content in lessonContents)
        {
            lessonContentLanguages.Add(
                new LessonContentLanguage(
                    content.Id,
                    english.Id,
                    $"English content for Lesson Content {content.Id}."));

            lessonContentLanguages.Add(
                new LessonContentLanguage(
                    content.Id,
                    korean.Id,
                    $"Lesson Content {content.Id}의 한국어 내용입니다."));
        }

        context.LessonContentLanguages.AddRange(lessonContentLanguages);

        await context.SaveChangesAsync();
    }
}