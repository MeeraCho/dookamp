using DooKamp.Application.DTOs.Quizzes;

namespace DooKamp.Application.DTOs.Lessons;

public sealed class LessonDetailDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public IReadOnlyCollection<LessonContentDto> Contents
        { get; init; } = [];

    public IReadOnlyCollection<QuizQuestionDto> QuizQuestions
        { get; init; } = [];
}