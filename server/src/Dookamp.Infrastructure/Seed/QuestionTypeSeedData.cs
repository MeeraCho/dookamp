namespace Dookamp.Infrastructure.Seed;

public sealed class QuestionTypeSeed
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
}

public static class QuestionTypeSeedData
{
    public static IReadOnlyList<QuestionTypeSeed> All { get; } =
    [
        new() { Id = 1, Name = "SingleChoice" },
        new() { Id = 2, Name = "MultipleChoice" },
        new() { Id = 3, Name = "TrueFalse" },
        new() { Id = 4, Name = "FillBlank" },
        new() { Id = 5, Name = "Matching" },
        new() { Id = 6, Name = "DragDrop" },
        new() { Id = 7, Name = "Ordering" }
    ];
}
