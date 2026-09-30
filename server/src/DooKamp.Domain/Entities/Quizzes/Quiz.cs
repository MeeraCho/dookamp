namespace DooKamp.Domain.Entities.Quizzes;

public sealed class Quiz : Entity
{
    private Quiz() { }

    public Quiz(
        string title,
        int order,
        int? lessonId = null,
        int? lessonContentId = null)
    {
        Title = title;
        Order = order;
        LessonId = lessonId;
        LessonContentId = lessonContentId;
    }

    public int? LessonId { get; private set; }

    public int? LessonContentId { get; private set; }

    public string Title { get; private set; } = string.Empty;

    public int Order { get; private set; }
}