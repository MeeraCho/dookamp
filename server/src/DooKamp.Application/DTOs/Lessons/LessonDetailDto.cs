using DooKamp.Application.DTOs.Quizzes;

namespace DooKamp.Application.DTOs.Lessons;

public sealed class LessonDetailDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }

    public IReadOnlyList<LessonContentDto> Contents
        { get; init; } = [];

    public IReadOnlyList<QuizQuestionDto> QuizQuestions
        { get; init; } = [];
}