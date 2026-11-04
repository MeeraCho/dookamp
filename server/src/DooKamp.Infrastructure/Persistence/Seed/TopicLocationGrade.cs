using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class TopicLocationGradeSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.TopicLocationGrades.AnyAsync())
            return;

        var alberta = await context.Locations.SingleAsync(x => x.Name == "Alberta");
        var grade3 = await context.Grades.SingleAsync(x => x.Name == "Grade 3");
        var grade4 = await context.Grades.SingleAsync(x => x.Name == "Grade 4");
        var grade5 = await context.Grades.SingleAsync(x => x.Name == "Grade 5");
        var grade6 = await context.Grades.SingleAsync(x => x.Name == "Grade 6");

        var topics = await context.Topics
            .OrderBy(x => x.Id)
            .ToListAsync();

        var topicLocationGrades = new List<TopicLocationGrade>();

        for (var i = 0; i < topics.Count; i++)
        {
            var gradeId = i switch
            {
                < 6 => grade3.Id,
                < 12 => grade4.Id,
                < 18 => grade5.Id,
                _ => grade6.Id
            };

            topicLocationGrades.Add(
                new TopicLocationGrade(
                    topics[i].Id,
                    alberta.Id,
                    gradeId));
        }

        context.TopicLocationGrades.AddRange(topicLocationGrades);

        await context.SaveChangesAsync();
    }
}