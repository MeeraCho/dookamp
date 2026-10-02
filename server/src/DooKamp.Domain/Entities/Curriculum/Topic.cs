using DooKamp.Domain.Entities.Lessons;

namespace DooKamp.Domain.Entities.Curriculum;

public sealed class Topic : Entity<int>
{
    private Topic() { }

    public Topic(
        string name,
        int subjectId,
        int? parentTopicId = null,
        string? description = null)
    {
        Name = name;
        SubjectId = subjectId;
        ParentTopicId = parentTopicId;
        Description = description;
    }

    public string Name { get; private set; } = string.Empty;

    public int? ParentTopicId { get; private set; }

    public int SubjectId { get; private set; }

    public string? Description { get; private set; }

    // Subject relationship
    public Subject Subject { get; private set; } = null!;

    // Self-referencing relationship
    public Topic? ParentTopic { get; private set; }

    public IReadOnlyCollection<Topic> ChildTopics { get; private set; } = new List<Topic>();

    // Lessons belonging to this topic 
    public IReadOnlyCollection<Lesson> Lessons { get; private set; } = new List<Lesson>();
}