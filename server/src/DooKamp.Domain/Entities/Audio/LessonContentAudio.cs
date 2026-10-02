using DooKamp.Domain.Entities.Languages;
using DooKamp.Domain.Entities.Lessons;
namespace DooKamp.Domain.Entities.Audio;

public sealed class LessonContentAudio : Entity<int>
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
    
    public LessonContent LessonContent { get; private set; } = null!;
		
    public Language Language { get; private set; } = null!; 
}