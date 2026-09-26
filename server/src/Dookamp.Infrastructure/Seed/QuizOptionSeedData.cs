namespace Dookamp.Infrastructure.Seed;

public sealed class QuizOptionSeed
{
    public int Id { get; init; }
    public int QuizQuestionId { get; init; }
    public bool IsCorrect { get; init; }
    public int SortOrder { get; init; }
}

public sealed class QuizOptionLanguageSeed
{
    public int Id { get; init; }
    public int QuizOptionId { get; init; }
    public int LanguageId { get; init; }
    public string Text { get; init; } = string.Empty;
}

public static class QuizOptionSeedData
{
    public static IReadOnlyList<QuizOptionSeed> Options { get; } =
    [
        new() { Id = 1, QuizQuestionId = 1, IsCorrect = true, SortOrder = 1 },
        new() { Id = 2, QuizQuestionId = 1, IsCorrect = false, SortOrder = 2 },
        new() { Id = 3, QuizQuestionId = 1, IsCorrect = false, SortOrder = 3 },
        new() { Id = 4, QuizQuestionId = 2, IsCorrect = true, SortOrder = 1 },
        new() { Id = 5, QuizQuestionId = 2, IsCorrect = false, SortOrder = 2 },
        new() { Id = 6, QuizQuestionId = 3, IsCorrect = true, SortOrder = 1 },
        new() { Id = 7, QuizQuestionId = 3, IsCorrect = false, SortOrder = 2 },
        new() { Id = 8, QuizQuestionId = 3, IsCorrect = false, SortOrder = 3 },
        new() { Id = 9, QuizQuestionId = 4, IsCorrect = true, SortOrder = 1 },
        new() { Id = 10, QuizQuestionId = 4, IsCorrect = true, SortOrder = 2 },
        new() { Id = 11, QuizQuestionId = 4, IsCorrect = true, SortOrder = 3 },
        new() { Id = 12, QuizQuestionId = 4, IsCorrect = true, SortOrder = 4 },
        new() { Id = 13, QuizQuestionId = 5, IsCorrect = true, SortOrder = 1 },
        new() { Id = 14, QuizQuestionId = 5, IsCorrect = false, SortOrder = 2 },
        new() { Id = 15, QuizQuestionId = 5, IsCorrect = false, SortOrder = 3 },
        new() { Id = 16, QuizQuestionId = 6, IsCorrect = true, SortOrder = 1 },
        new() { Id = 17, QuizQuestionId = 6, IsCorrect = false, SortOrder = 2 },
        new() { Id = 18, QuizQuestionId = 7, IsCorrect = true, SortOrder = 1 },
        new() { Id = 19, QuizQuestionId = 7, IsCorrect = false, SortOrder = 2 },
        new() { Id = 20, QuizQuestionId = 7, IsCorrect = false, SortOrder = 3 },
        new() { Id = 21, QuizQuestionId = 8, IsCorrect = true, SortOrder = 1 },
        new() { Id = 22, QuizQuestionId = 8, IsCorrect = false, SortOrder = 2 },
        new() { Id = 23, QuizQuestionId = 8, IsCorrect = false, SortOrder = 3 },
        new() { Id = 24, QuizQuestionId = 9, IsCorrect = true, SortOrder = 1 },
        new() { Id = 25, QuizQuestionId = 9, IsCorrect = false, SortOrder = 2 },
        new() { Id = 26, QuizQuestionId = 10, IsCorrect = true, SortOrder = 1 },
        new() { Id = 27, QuizQuestionId = 10, IsCorrect = false, SortOrder = 2 },
        new() { Id = 28, QuizQuestionId = 10, IsCorrect = false, SortOrder = 3 }
    ];

    public static IReadOnlyList<QuizOptionLanguageSeed> Languages { get; } =
    [
        new() { Id = 1, QuizOptionId = 1, LanguageId = 1, Text = "What the air and sky are like" },
        new() { Id = 2, QuizOptionId = 2, LanguageId = 1, Text = "How much sunlight there is" },
        new() { Id = 3, QuizOptionId = 3, LanguageId = 1, Text = "How fast the wind moves" },
        new() { Id = 4, QuizOptionId = 4, LanguageId = 1, Text = "True" },
        new() { Id = 5, QuizOptionId = 5, LanguageId = 1, Text = "False" },
        new() { Id = 6, QuizOptionId = 6, LanguageId = 1, Text = "Thermometer" },
        new() { Id = 7, QuizOptionId = 7, LanguageId = 1, Text = "Hygrometer" },
        new() { Id = 8, QuizOptionId = 8, LanguageId = 1, Text = "Anemometer" },
        new() { Id = 9, QuizOptionId = 9, LanguageId = 1, Text = "Rain" },
        new() { Id = 10, QuizOptionId = 10, LanguageId = 1, Text = "Snow" },
        new() { Id = 11, QuizOptionId = 11, LanguageId = 1, Text = "Sleet" },
        new() { Id = 12, QuizOptionId = 12, LanguageId = 1, Text = "Hail" },
        new() { Id = 13, QuizOptionId = 13, LanguageId = 1, Text = "Moving air" },
        new() { Id = 14, QuizOptionId = 14, LanguageId = 1, Text = "Water vapor" },
        new() { Id = 15, QuizOptionId = 15, LanguageId = 1, Text = "Cloud" },
        new() { Id = 16, QuizOptionId = 16, LanguageId = 1, Text = "True" },
        new() { Id = 17, QuizOptionId = 17, LanguageId = 1, Text = "False" },
        new() { Id = 18, QuizOptionId = 18, LanguageId = 1, Text = "How many clouds are in sky" },
        new() { Id = 19, QuizOptionId = 19, LanguageId = 1, Text = "How much rain falls" },
        new() { Id = 20, QuizOptionId = 20, LanguageId = 1, Text = "How fast wind moves" },
        new() { Id = 21, QuizOptionId = 21, LanguageId = 1, Text = "The weight of air pressing down" },
        new() { Id = 22, QuizOptionId = 22, LanguageId = 1, Text = "The amount of sunlight" },
        new() { Id = 23, QuizOptionId = 23, LanguageId = 1, Text = "The amount of water in air" },
        new() { Id = 24, QuizOptionId = 24, LanguageId = 1, Text = "True" },
        new() { Id = 25, QuizOptionId = 25, LanguageId = 1, Text = "False" },
        new() { Id = 26, QuizOptionId = 26, LanguageId = 1, Text = "The weather forecast" },
        new() { Id = 27, QuizOptionId = 27, LanguageId = 1, Text = "A thermometer" },
        new() { Id = 28, QuizOptionId = 28, LanguageId = 1, Text = "A sunshine recorder" }
    ];
}
