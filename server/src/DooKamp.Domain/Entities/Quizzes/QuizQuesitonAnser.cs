using DooKamp.Domain.Entities;
using DooKamp.Domain.Entities.Languages;
using DooKamp.Domain.Entities.Quizzes;

public sealed class QuizQuestionAnswer : Entity<int>
{
    private QuizQuestionAnswer() { }

    public QuizQuestionAnswer(
        int quizQuestionId,
        int languageId,
        string answer)
    {
        QuizQuestionId = quizQuestionId;
        LanguageId = languageId;
        Answer = answer;
    }

    public int QuizQuestionId { get; private set; }

    public int LanguageId { get; private set; }

    public string Answer { get; private set; } = string.Empty;

    public QuizQuestion QuizQuestion { get; private set; } = null!;

    public Language Language { get; private set; } = null!;
}