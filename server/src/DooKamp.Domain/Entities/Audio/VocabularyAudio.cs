using DooKamp.Domain.Entities.Vocabs;
using DooKamp.Domain.Entities.Languages;

namespace DooKamp.Domain.Entities.Audio;

public sealed class VocabularyAudio : Entity<int>
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

    public Vocabulary Vocabulary { get; private set; } = null!;

    public Language Language { get; private set; } = null!;    
}