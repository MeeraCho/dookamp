using DooKamp.Domain.Entities.Vocabs;

namespace DooKamp.Domain.Entities.Media;

public sealed class VocabularyMedia : Entity<int>
{
    private VocabularyMedia() { }

    public VocabularyMedia(
        int vocabularyId,
        int mediaId)
    {
        VocabularyId = vocabularyId;
        MediaId = mediaId;
    }

    public int VocabularyId { get; private set; }

    public int MediaId { get; private set; }

    // Navigation Properties
    public Vocabulary Vocabulary { get; private set; } = null!;
    public Media Media { get; private set; } = null!;
}