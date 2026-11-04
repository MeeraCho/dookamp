namespace DooKamp.Domain.Entities.Curriculum;

public sealed class TopicLocationGrade : Entity<int>
{
    private TopicLocationGrade() { }

    public TopicLocationGrade(
        int topicId,
        int locationId,
        int gradeId)
    {
        TopicId = topicId;
        LocationId = locationId;
        GradeId = gradeId;
    }

    public int TopicId { get; private set; }

    public int LocationId { get; private set; }

    public int GradeId { get; private set; }

    // Navigation Properties
    public Topic Topic { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public Grade Grade { get; private set; } = null!;
}