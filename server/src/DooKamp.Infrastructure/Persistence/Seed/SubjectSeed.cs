using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class SubjectSeed
{
    public static async Task SeedAsync(
        DooKampDbContext context)
    {
        if (await context.Subjects.AnyAsync())
            return;

        var subjects = new[]
        {
            new Subject("Science"),
            new Subject("Social Studies"),
            new Subject("Mathematics"),
            new Subject("English Language Arts")
        };

        await context.Subjects.AddRangeAsync(subjects);
        await context.SaveChangesAsync();
    }
}