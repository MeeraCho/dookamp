using DooKamp.Domain.Entities.Languages;

namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizOptionLanguage : Entity<int>
{
    private QuizOptionLanguage() { }

    public QuizOptionLanguage(
        int quizOptionId,
        int languageId,
        string text)
    {
        QuizOptionId = quizOptionId;
        LanguageId = languageId;
        Text = text;
    }

    public int QuizOptionId { get; private set; }

    public int LanguageId { get; private set; }

    public string Text { get; private set; } = string.Empty;

    // Navigation Properties
    public QuizOption QuizOption { get; private set; } = null!;

    public Language Language { get; private set; } = null!;
}