namespace Dookamp.Application.Lessons;

public sealed record LessonDetails(
    int Id,
    int TopicId,
    string Name,
    string? Description,
    IReadOnlyList<LessonContentDetails> Contents,
    IReadOnlyList<QuizQuestionDetails> Questions);

public sealed record LessonContentDetails(
    int Id,
    int SortOrder,
    string Text);

public sealed record QuizQuestionDetails(
    int Id,
    int QuestionTypeId,
    int SortOrder,
    string QuestionText,
    IReadOnlyList<QuizOptionDetails> Options);

public sealed record QuizOptionDetails(
    int Id,
    int SortOrder,
    bool IsCorrect,
    string Text);

public interface ILessonQueries
{
    Task<LessonDetails?> GetByIdAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default);
}

public sealed class GetLessonByIdHandler(ILessonQueries lessonQueries)
{
    public Task<LessonDetails?> HandleAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default) =>
        lessonQueries.GetByIdAsync(lessonId, languageId, cancellationToken);
}
