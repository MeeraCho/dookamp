using DooKamp.Domain.Entities.Languages;

namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizQuestionLanguage : Entity<int>
{
    private QuizQuestionLanguage() { }

    public QuizQuestionLanguage(
        int quizQuestionId,
        int languageId,
        string questionText)
    {
        QuizQuestionId = quizQuestionId;
        LanguageId = languageId;
        QuestionText = questionText;
    }

    public int QuizQuestionId { get; private set; }

    public int LanguageId { get; private set; }

    public string QuestionText { get; private set; } = string.Empty;

    // Navigation Properties
    public QuizQuestion QuizQuestion { get; private set; } = null!;

    public Language Language { get; private set; } = null!;
}