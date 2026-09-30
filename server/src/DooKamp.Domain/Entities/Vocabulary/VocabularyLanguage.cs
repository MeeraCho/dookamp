namespace DooKamp.Domain.Entities.Vocabulary;

public sealed class VocabularyLanguage : Entity
{
    private VocabularyLanguage() { }

    public VocabularyLanguage(
        int vocabularyId,
        int languageId,
        string word,
        string definition)
    {
        VocabularyId = vocabularyId;
        LanguageId = languageId;
        Word = word;
        Definition = definition;
    }

    public int VocabularyId { get; private set; }

    public int LanguageId { get; private set; }

    public string Word { get; private set; } = string.Empty;

    public string Definition { get; private set; } = string.Empty;
}