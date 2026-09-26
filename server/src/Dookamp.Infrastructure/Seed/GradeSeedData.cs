namespace Dookamp.Infrastructure.Seed;

public sealed class GradeSeed
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public static class GradeSeedData
{
    public static IReadOnlyList<GradeSeed> All { get; } =
    [
        new() { Id = 1, Name = "Grade 1" },
        new() { Id = 2, Name = "Grade 2" },
        new() { Id = 3, Name = "Grade 3" },
        new() { Id = 4, Name = "Grade 4" },
        new() { Id = 5, Name = "Grade 5" },
        new() { Id = 6, Name = "Grade 6" },
        new() { Id = 7, Name = "Grade 7" },
        new() { Id = 8, Name = "Grade 8" },
        new() { Id = 9, Name = "Grade 9" },
        new() { Id = 10, Name = "Grade 10" },
        new() { Id = 11, Name = "Grade 11" },
        new() { Id = 12, Name = "Grade 12" }
    ];
}
