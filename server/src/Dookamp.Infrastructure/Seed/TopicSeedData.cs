namespace Dookamp.Infrastructure.Seed;

public sealed class TopicSeed
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int? ParentTopicId { get; init; }
    public int SubjectId { get; init; }
    public string Description { get; init; } = string.Empty;
}

public static class TopicSeedData
{
    public static IReadOnlyList<TopicSeed> All { get; } =
    [
        new() { Id = 1, Name = "Biology", SubjectId = 1, Description = "The study of living things and life processes" },
        new() { Id = 2, Name = "Body Systems", ParentTopicId = 1, SubjectId = 1, Description = "Systems that work together to support the human body" },
        new() { Id = 3, Name = "Circulatory System", ParentTopicId = 2, SubjectId = 1, Description = "The system that moves blood, oxygen, and nutrients through the body" },
        new() { Id = 4, Name = "Organs", ParentTopicId = 2, SubjectId = 1, Description = "Major organs and their functions in the human body" },
        new() { Id = 5, Name = "Nervous System", ParentTopicId = 2, SubjectId = 1, Description = "The system that controls and coordinates body functions" },
        new() { Id = 6, Name = "Respiratory System", ParentTopicId = 2, SubjectId = 1, Description = "The system responsible for taking in oxygen and removing carbon dioxide" },
        new() { Id = 7, Name = "Digestive System", ParentTopicId = 2, SubjectId = 1, Description = "The system that breaks down food and absorbs nutrients" },
        new() { Id = 8, Name = "Weather & Climate", SubjectId = 1, Description = "Weather conditions and long-term climate patterns" },
        new() { Id = 9, Name = "Weather", ParentTopicId = 8, SubjectId = 1, Description = "Conditions of the atmosphere at a particular time and place" },
        new() { Id = 10, Name = "Climate", ParentTopicId = 8, SubjectId = 1, Description = "Long-term patterns of weather in a region" },
        new() { Id = 11, Name = "Atmospheric Conditions", ParentTopicId = 8, SubjectId = 1, Description = "Temperature, precipitation, wind, humidity, clouds, air pressure, and sunshine" },
        new() { Id = 12, Name = "Matter", SubjectId = 1, Description = "The properties and changes of matter" },
        new() { Id = 13, Name = "Energy", SubjectId = 1, Description = "Different forms of energy and how energy changes or moves" }
    ];
}
