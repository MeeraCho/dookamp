namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizQuestion : Entity<int>
{
    private QuizQuestion() { }

    public QuizQuestion(
        int quizId,
        int questionTypeId,
        int order)
    {
        QuizId = quizId;
        QuestionTypeId = questionTypeId;
        Order = order;
    }

    public int QuizId { get; private set; }

    public int QuestionTypeId { get; private set; }

    public int Order { get; private set; }
}