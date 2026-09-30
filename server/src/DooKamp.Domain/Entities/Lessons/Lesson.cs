using DooKamp.Domain.Enums;
namespace DooKamp.Domain.Entities.Lessons;

public sealed class Lesson : Entity
{
    private Lesson() { }

    public Lesson(
        string title,
        int topicId,
        string? description = null)
    {
        Title = title;
        TopicId = topicId;
        Description = description;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
        Status = LessonStatus.Draft;        
    }

    public string Title { get; private set; } = string.Empty;

    public int TopicId { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public LessonStatus Status { get; private set; } //publishing lifecycle

    public DateTime? PublishedAt { get; private set; }
}