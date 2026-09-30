namespace DooKamp.Domain.Entities.Media;

public sealed class LessonContentMedia
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