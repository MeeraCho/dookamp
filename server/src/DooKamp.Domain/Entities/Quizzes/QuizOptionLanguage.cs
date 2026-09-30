namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizOptionLanguage : Entity
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
}