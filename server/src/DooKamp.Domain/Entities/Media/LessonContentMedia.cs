namespace DooKamp.Domain.Entities.Media;

public sealed class LessonContentMedia: Entity<int>
{
    private LessonContentMedia() { }

    public LessonContentMedia(
        int lessonContentId,
        int mediaId)
    {
        LessonContentId = lessonContentId;
        MediaId = mediaId;
    }

    public int LessonContentId { get; private set; }

    public int MediaId { get; private set; }
}