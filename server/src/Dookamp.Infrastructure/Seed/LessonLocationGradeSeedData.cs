namespace Dookamp.Infrastructure.Seed;

public sealed class LessonLocationGradeSeed
{
    public int Id { get; init; }
    public int LessonId { get; init; }
    public int LocationId { get; init; }
    public int GradeId { get; init; }
}

public static class LessonLocationGradeSeedData
{
    public static IReadOnlyList<LessonLocationGradeSeed> All { get; } =
    [
        new() { Id = 1, LessonId = 1, LocationId = 1, GradeId = 5 },
        new() { Id = 2, LessonId = 1, LocationId = 2, GradeId = 6 },
        new() { Id = 3, LessonId = 1, LocationId = 7, GradeId = 5 },
        new() { Id = 4, LessonId = 2, LocationId = 1, GradeId = 5 },
        new() { Id = 5, LessonId = 2, LocationId = 2, GradeId = 6 },
        new() { Id = 6, LessonId = 2, LocationId = 7, GradeId = 5 },
        
    ];
}
