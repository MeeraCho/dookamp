namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuestionType : Entity<int>
{
    private QuestionType() { }

    public QuestionType(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;
}