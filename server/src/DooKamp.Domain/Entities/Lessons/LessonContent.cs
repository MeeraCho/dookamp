namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonContent : Entity<int>
{
    private LessonContent() { }

    public LessonContent(
        int lessonId,
        int order)
    {
        LessonId = lessonId;
        Order = order;
    }

    public int LessonId { get; private set; }

    public int Order { get; private set; }
}