using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonTopic : Entity<int>
{
    private LessonTopic() { }

    public LessonTopic(
        int lessonId,
        int topicId)
    {
        LessonId = lessonId;
        TopicId = topicId;
    }

    public int LessonId { get; private set; }

    public int TopicId { get; private set; }

    // Navigation Properties
    public Lesson Lesson { get; private set; } = null!;

    public Topic Topic { get; private set; } = null!;
}