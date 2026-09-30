namespace DooKamp.Domain.Entities.Curriculum;

public sealed class Topic : Entity
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
}