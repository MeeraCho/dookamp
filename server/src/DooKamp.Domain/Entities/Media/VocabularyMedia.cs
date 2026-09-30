namespace DooKamp.Domain.Entities.Media;

public sealed class VocabularyMedia
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
}