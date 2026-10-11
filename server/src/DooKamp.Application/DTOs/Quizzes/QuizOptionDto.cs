namespace DooKamp.Application.DTOs.Quizzes;

public sealed class QuizOptionDto
{
    public int Id { get; init; }

    public string Text { get; init; } = string.Empty;

    public string LanguageCode { get; init; } = string.Empty;

    public int Order { get; init; }
}