using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Domain.Entities.Lessons;

namespace DooKamp.Domain.Entities.Topics;

public sealed class TopicLesson : Entity<int>
{
    private TopicLesson() { }

    public TopicLesson(
        int lessonId,
        int topicId)
    {
        LessonId = lessonId;
        TopicId = topicId;
    }

    public int TopicId { get; private set; }
    public int LessonId { get; private set; }

    // Navigation Properties
    public Topic Topic { get; private set; } = null!;    
    public Lesson Lesson { get; private set; } = null!;
}