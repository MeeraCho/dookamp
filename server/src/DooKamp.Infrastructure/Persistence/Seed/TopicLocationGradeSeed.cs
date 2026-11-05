
using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class TopicLocationGradeSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.TopicLocationGrades.AnyAsync())
            return;

        // Locations
        var ab = await context.Locations
            .SingleAsync(x => x.Code == "AB");

        var bc = await context.Locations
            .SingleAsync(x => x.Code == "BC");

        // Topics that should be available in both Alberta and BC
        var bcTopicNames = new HashSet<string>
        {
            // Add topic names here
            "Cell Structure",
            "Cell Membrane",
            "Nucleus"
        };

        // Grade 1 to Grade 6
        var gradeNames = Enumerable.Range(1, 6)
            .Select(i => $"Grade {i}")
            .ToArray();

        var grades = await context.Grades
            .Where(x => gradeNames.Contains(x.Name))
            .ToListAsync();

        if (grades.Count != 6)
            throw new InvalidOperationException(
                "Grade 1 to Grade 6 must exist before seeding TopicLocationGrades.");

        var gradeByName = grades.ToDictionary(x => x.Name);

        var orderedGrades = gradeNames
            .Select(name => gradeByName[name])
            .ToList();

        // Load all topics
        var topics = await context.Topics
            .OrderBy(x => x.Name)
            .ToListAsync();

        var topicById = topics.ToDictionary(x => x.Id);

        // Find topics that have no children
        var parentTopicIds = topics
            .Where(x => x.ParentTopicId.HasValue)
            .Select(x => x.ParentTopicId!.Value)
            .ToHashSet();

        var leafTopics = topics
            .Where(x => !parentTopicIds.Contains(x.Id))
            .ToList();

        var topicLocationGrades = new List<TopicLocationGrade>();

        var addedMappings =
            new HashSet<(int TopicId, int LocationId, int GradeId)>();

        // Distribute leaf topics across Grade 1 to Grade 6
        for (var i = 0; i < leafTopics.Count; i++)
        {
            var grade = orderedGrades[i % orderedGrades.Count];
            var leafTopic = leafTopics[i];

            // All topics are mapped to Alberta.
            // Selected topics are also mapped to BC.
            var locations = bcTopicNames.Contains(leafTopic.Name)
                ? new[] { ab, bc }
                : new[] { ab };

            foreach (var location in locations)
            {
                var currentTopic = leafTopic;

                // Also map all parent topics to the same location and grade.
                while (true)
                {
                    if (addedMappings.Add(
                        (currentTopic.Id, location.Id, grade.Id)))
                    {
                        topicLocationGrades.Add(
                            new TopicLocationGrade(
                                currentTopic.Id,
                                location.Id,
                                grade.Id));
                    }

                    if (!currentTopic.ParentTopicId.HasValue)
                        break;

                    currentTopic =
                        topicById[currentTopic.ParentTopicId.Value];
                }
            }
        }

        context.TopicLocationGrades.AddRange(topicLocationGrades);

        await context.SaveChangesAsync();
    }
}
