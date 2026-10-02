using DooKamp.Domain.Enums;

namespace DooKamp.Domain.Entities.Media;

public sealed class Media : Entity<int>
{
    private Media() { }

    public Media(MediaType mediaType, string url)
    {
        MediaType = mediaType;
        Url = url;
    }

    public MediaType MediaType { get; private set; }

    public string Url { get; private set; } = string.Empty;

    // Navigation Properties
    public IReadOnlyCollection<LessonContentMedia> LessonContentMedias
        { get; private set; } = new List<LessonContentMedia>();

    public IReadOnlyCollection<VocabularyMedia> VocabularyMedias
        { get; private set; } = new List<VocabularyMedia>();
}