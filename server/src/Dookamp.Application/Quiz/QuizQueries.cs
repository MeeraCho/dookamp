namespace Dookamp.Application.Quiz;

public sealed record QuizDetails(
    int LessonId,
    IReadOnlyList<QuizQuestionDetails> Questions);

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

public interface IQuizQueries
{
    Task<QuizDetails?> GetForLessonAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default);
}

public sealed class GetLessonQuizHandler(IQuizQueries quizQueries)
{
    public Task<QuizDetails?> HandleAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default) =>
        quizQueries.GetForLessonAsync(lessonId, languageId, cancellationToken);
}
