namespace Dookamp.Application.Vocabulary;

public sealed record VocabularyDetails(
    int Id,
    string Word,
    string Definition);

public interface IVocabularyQueries
{
    Task<IReadOnlyList<VocabularyDetails>> GetForLessonAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default);
}

public sealed class GetLessonVocabularyHandler(IVocabularyQueries vocabularyQueries)
{
    public Task<IReadOnlyList<VocabularyDetails>> HandleAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default) =>
        vocabularyQueries.GetForLessonAsync(lessonId, languageId, cancellationToken);
}
