using DooKamp.Application.DTOs.Quizzes;

namespace DooKamp.Application.DTOs.Lessons;

public sealed class LessonContentDto
{
    public int Id { get; init; }

    public int Order { get; init; }

    public string LanguageCode { get; init; } = string.Empty;

    public string Text { get; init; } = string.Empty;

    public IReadOnlyCollection<VocabularyDto> Vocabularies
        { get; init; } = [];

    public IReadOnlyCollection<QuizQuestionDto> ConceptCheckQuestions
        { get; init; } = [];
}