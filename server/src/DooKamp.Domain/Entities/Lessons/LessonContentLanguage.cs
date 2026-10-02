using DooKamp.Domain.Entities.Languages;
namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonContentLanguage : Entity<int>
{
    private LessonContentLanguage() { }

    public LessonContentLanguage(
        int lessonContentId,
        int languageId,
        string text)
    {
        LessonContentId = lessonContentId;
        LanguageId = languageId;
        Text = text;
    }

    public int LessonContentId { get; private set; }

    public int LanguageId { get; private set; }

    public string Text { get; private set; } = string.Empty;
    
    // Navigation Properties
    public LessonContent LessonContent { get; private set; } = null!;
    public Language Language { get; private set; } = null!;    
}