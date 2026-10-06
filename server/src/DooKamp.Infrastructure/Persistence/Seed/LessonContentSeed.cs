using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonContentSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.LessonContents.AnyAsync())
            return;

        var lessons = await context.Lessons
            .OrderBy(x => x.Id)
            .ToListAsync();

        var lessonContents = new List<LessonContent>();

        foreach (var lesson in lessons)
        {
            lessonContents.Add(new LessonContent(lesson.Id, 1));
            lessonContents.Add(new LessonContent(lesson.Id, 2));
            lessonContents.Add(new LessonContent(lesson.Id, 3));
        }

        context.LessonContents.AddRange(lessonContents);

        await context.SaveChangesAsync();
    }
}