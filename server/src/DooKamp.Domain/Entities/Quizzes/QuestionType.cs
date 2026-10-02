namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuestionType : Entity<int>
{
    private QuestionType() { }

    public QuestionType(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;

    // Navigation Properties
    public IReadOnlyCollection<QuizQuestion> QuizQuestions
        { get; private set; } = new List<QuizQuestion>();
}