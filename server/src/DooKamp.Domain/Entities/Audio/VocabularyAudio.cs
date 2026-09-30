namespace DooKamp.Domain.Entities.Vocabulary;

public sealed class VocabularyAudio : Entity
{
    private VocabularyAudio() { }

    public VocabularyAudio(
        int vocabularyId,
        int languageId,
        string? audioUrl = null)
    {
        VocabularyId = vocabularyId;
        LanguageId = languageId;
        AudioUrl = audioUrl;
    }

    public int VocabularyId { get; private set; }

    public int LanguageId { get; private set; }

    public string? AudioUrl { get; private set; }
}