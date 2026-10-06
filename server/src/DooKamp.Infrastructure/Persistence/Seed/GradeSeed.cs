using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class GradeSeed
{
    public static async Task SeedAsync(
        DooKampDbContext context)
    {
        if (await context.Grades.AnyAsync())
            return;

        var grades = new[]
        {
            new Grade("Grade 1"),
            new Grade("Grade 2"),
            new Grade("Grade 3"),
            new Grade("Grade 4"),
            new Grade("Grade 5"),
            new Grade("Grade 6"),
            new Grade("Grade 7"),
            new Grade("Grade 8"),
            new Grade("Grade 9"),
            new Grade("Grade 10"),
            new Grade("Grade 11"),
            new Grade("Grade 12")
        };

        await context.Grades.AddRangeAsync(grades);
        await context.SaveChangesAsync();
    }
}