using DooKamp.Domain.Entities.Lessons;
namespace DooKamp.Domain.Entities.Vocabs;

public sealed class LessonContentVocabulary : Entity<int>
{
    private LessonContentVocabulary() { }

    public LessonContentVocabulary(
        int lessonContentId,
        int vocabularyId)
    {
        LessonContentId = lessonContentId;
        VocabularyId = vocabularyId;
    }

    public int LessonContentId { get; private set; }

    public int VocabularyId { get; private set; }

    // Navigation Properties
    public LessonContent LessonContent { get; private set; } = null!;

    public Vocabulary Vocabulary { get; private set; } = null!;
}