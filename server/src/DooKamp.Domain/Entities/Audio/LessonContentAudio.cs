namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonContentAudio : Entity
{
    private LessonContentAudio() { }

    public LessonContentAudio(
        int lessonContentId,
        int languageId,
        string? audioUrl = null)
    {
        LessonContentId = lessonContentId;
        LanguageId = languageId;
        AudioUrl = audioUrl;
    }

    public int LessonContentId { get; private set; }

    public int LanguageId { get; private set; }

    public string? AudioUrl { get; private set; }
}