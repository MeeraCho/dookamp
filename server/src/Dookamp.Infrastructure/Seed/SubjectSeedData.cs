namespace Dookamp.Infrastructure.Seed;

public sealed class SubjectSeed
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public static class SubjectSeedData
{
    public static IReadOnlyList<SubjectSeed> All { get; } =
    [
        new() { Id = 1, Name = "Science" },
        new() { Id = 2, Name = "Social Studies" },
        new() { Id = 3, Name = "Mathematics" },
        new() { Id = 4, Name = "English Language Arts" }
    ];
}
