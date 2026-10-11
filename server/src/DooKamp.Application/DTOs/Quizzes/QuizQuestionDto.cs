namespace DooKamp.Application.DTOs.Quizzes;

public sealed class QuizQuestionDto
{
    public int Id { get; init; }

    public string QuestionText { get; init; } = string.Empty;

    public string LanguageCode { get; init; } = string.Empty;

    public int Order { get; init; }

    public IReadOnlyCollection<QuizOptionDto> Options { get; init; } = [];
}