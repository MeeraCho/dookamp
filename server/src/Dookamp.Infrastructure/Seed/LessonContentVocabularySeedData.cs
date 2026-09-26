namespace Dookamp.Infrastructure.Seed;

public sealed class LessonContentVocabularySeed
{
    public int Id { get; init; }
    public int LessonContentId { get; init; }
    public int VocabularyId { get; init; }
}

public static class LessonContentVocabularySeedData
{
    public static IReadOnlyList<LessonContentVocabularySeed> All { get; } =
    [
        new() { Id = 1, LessonContentId = 1, VocabularyId = 1 },
        new() { Id = 2, LessonContentId = 2, VocabularyId = 1 },
        new() { Id = 3, LessonContentId = 2, VocabularyId = 2 },
        new() { Id = 4, LessonContentId = 2, VocabularyId = 3 },
        new() { Id = 5, LessonContentId = 5, VocabularyId = 3 },
        new() { Id = 6, LessonContentId = 6, VocabularyId = 4 },
        new() { Id = 7, LessonContentId = 6, VocabularyId = 5 },
        new() { Id = 8, LessonContentId = 6, VocabularyId = 6 },
        new() { Id = 9, LessonContentId = 6, VocabularyId = 7 },
        new() { Id = 10, LessonContentId = 7, VocabularyId = 8 },
        new() { Id = 11, LessonContentId = 8, VocabularyId = 9 }
    ];
}
