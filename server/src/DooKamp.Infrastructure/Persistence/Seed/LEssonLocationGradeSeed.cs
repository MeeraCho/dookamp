using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonLocationGradeSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.LessonLocationGrades.AnyAsync())
            return;

        var canada = await context.Locations.SingleAsync(x => x.Name == "Alberta");
        var grade3 = await context.Grades.SingleAsync(x => x.Name == "Grade 3");
        var grade4 = await context.Grades.SingleAsync(x => x.Name == "Grade 4");
        var grade5 = await context.Grades.SingleAsync(x => x.Name == "Grade 5");
        var grade6 = await context.Grades.SingleAsync(x => x.Name == "Grade 6");

        var lessons = await context.Lessons
            .OrderBy(x => x.Id)
            .ToListAsync();

        var lessonLocationGrades = new List<LessonLocationGrade>();

        for (var i = 0; i < lessons.Count; i++)
        {
            var gradeId = i switch
            {
                < 6 => grade3.Id,
                < 12 => grade4.Id,
                < 18 => grade5.Id,
                _ => grade6.Id
            };

            lessonLocationGrades.Add(
                new LessonLocationGrade(
                    lessons[i].Id,
                    canada.Id,
                    gradeId));
        }

        context.LessonLocationGrades.AddRange(lessonLocationGrades);

        await context.SaveChangesAsync();
    }
}