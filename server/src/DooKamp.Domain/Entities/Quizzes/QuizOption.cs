namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizOption : Entity<int>
{
    private QuizOption() { }

    public QuizOption(
        int quizQuestionId,
        bool isCorrect,
        int order)
    {
        QuizQuestionId = quizQuestionId;
        IsCorrect = isCorrect;
        Order = order;
    }

    public int QuizQuestionId { get; private set; }

    public bool IsCorrect { get; private set; }

    public int Order { get; private set; }
}