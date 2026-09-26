namespace Dookamp.Infrastructure.Seed;

public sealed class QuizQuestionSeed
{
    public int Id { get; init; }
    public int LessonId { get; init; }
    public int QuestionTypeId { get; init; }
    public int SortOrder { get; init; }
}

public sealed class QuizQuestionLanguageSeed
{
    public int Id { get; init; }
    public int QuizQuestionId { get; init; }
    public int LanguageId { get; init; }
    public string QuestionText { get; init; } = string.Empty;
}

public static class QuizQuestionSeedData
{
    public static IReadOnlyList<QuizQuestionSeed> Questions { get; } =
    [
        new() { Id = 1, LessonId = 1, QuestionTypeId = 1, SortOrder = 1 },
        new() { Id = 2, LessonId = 1, QuestionTypeId = 3, SortOrder = 2 },
        new() { Id = 3, LessonId = 1, QuestionTypeId = 1, SortOrder = 3 },
        new() { Id = 4, LessonId = 1, QuestionTypeId = 2, SortOrder = 4 },
        new() { Id = 5, LessonId = 1, QuestionTypeId = 1, SortOrder = 5 },
        new() { Id = 6, LessonId = 1, QuestionTypeId = 3, SortOrder = 6 },
        new() { Id = 7, LessonId = 1, QuestionTypeId = 1, SortOrder = 7 },
        new() { Id = 8, LessonId = 1, QuestionTypeId = 1, SortOrder = 8 },
        new() { Id = 9, LessonId = 1, QuestionTypeId = 3, SortOrder = 9 },
        new() { Id = 10, LessonId = 1, QuestionTypeId = 1, SortOrder = 10 },
        new() { Id = 11, LessonId = 1, QuestionTypeId = 1, SortOrder = 11 }
    ];

    public static IReadOnlyList<QuizQuestionLanguageSeed> Languages { get; } =
    [
        new() { Id = 1, QuizQuestionId = 1, LanguageId = 1, QuestionText = "What is weather?" },
        new() { Id = 2, QuizQuestionId = 2, LanguageId = 1, QuestionText = "Temperature tells us how hot or cold it is." },
        new() { Id = 3, QuizQuestionId = 3, LanguageId = 1, QuestionText = "What measures temperature?" },
        new() { Id = 4, QuizQuestionId = 4, LanguageId = 1, QuestionText = "Which are types of precipitation?" },
        new() { Id = 5, QuizQuestionId = 5, LanguageId = 1, QuestionText = "What is wind?" },
        new() { Id = 6, QuizQuestionId = 6, LanguageId = 1, QuestionText = "A hygrometer measures humidity." },
        new() { Id = 7, QuizQuestionId = 7, LanguageId = 1, QuestionText = "What does cloudiness tell us?" },
        new() { Id = 8, QuizQuestionId = 8, LanguageId = 1, QuestionText = "What is atmospheric pressure?" },
        new() { Id = 9, QuizQuestionId = 9, LanguageId = 1, QuestionText = "Weather can change quickly." },
        new() { Id = 10, QuizQuestionId = 10, LanguageId = 1, QuestionText = "What should you check before planning your day?" }
    ];
}
