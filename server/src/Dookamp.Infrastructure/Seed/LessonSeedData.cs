namespace Dookamp.Infrastructure.Seed;

public sealed class LessonSeed
{
    public int Id { get; init; }
    public int TopicId { get; init; }
    public bool IsPublished { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}

public sealed class LessonLanguageSeed
{
    public int Id { get; init; }
    public int LessonId { get; init; }
    public int LanguageId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}

public static class LessonSeedData
{
    private static readonly DateTime SeedTimestamp = new(2026, 9, 26, 0, 0, 0, DateTimeKind.Utc);

    public static IReadOnlyList<LessonSeed> Lessons { get; } =
    [
        new() { Id = 1, TopicId = 9, IsPublished = false, CreatedAt = SeedTimestamp, UpdatedAt = SeedTimestamp },
        new() { Id = 2, TopicId = 3, IsPublished = false, CreatedAt = SeedTimestamp, UpdatedAt = SeedTimestamp }
    ];

    public static IReadOnlyList<LessonLanguageSeed> Languages { get; } =
    [
        new() { Id = 1, LessonId = 1, LanguageId = 1, Name = "Weather", Description = "An introduction to weather and the factors that make up weather" },
        new() { Id = 2, LessonId = 2, LanguageId = 1, Name = "Circulatory System", Description = "An introduction to the circulatory system, its organs, and blood flow" }
    ];
}
