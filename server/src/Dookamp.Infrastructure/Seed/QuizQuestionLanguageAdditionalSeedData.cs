namespace Dookamp.Infrastructure.Seed;

public static class QuizQuestionLanguageAdditionalSeedData
{
    public static IReadOnlyList<QuizQuestionLanguageSeed> All { get; } =
    [
        new() { Id = 11, QuizQuestionId = 1, LanguageId = 2, QuestionText = "날씨란 무엇인가?" },
        new() { Id = 12, QuizQuestionId = 1, LanguageId = 3, QuestionText = "¿Qué es el tiempo?" },
        new() { Id = 13, QuizQuestionId = 11, LanguageId = 1, QuestionText = "What tool measures temperature?" },
        new() { Id = 14, QuizQuestionId = 11, LanguageId = 2, QuestionText = "기온을 측정하는 도구는 무엇인가?" },
        new() { Id = 15, QuizQuestionId = 11, LanguageId = 3, QuestionText = "¿Qué instrumento mide la temperatura?" }
    ];
}
