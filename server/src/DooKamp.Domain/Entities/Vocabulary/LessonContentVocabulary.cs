namespace DooKamp.Domain.Entities.Vocabulary;

public sealed class LessonContentVocabulary : Entity
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
}