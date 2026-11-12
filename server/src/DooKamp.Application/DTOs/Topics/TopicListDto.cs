namespace DooKamp.Application.DTOs.Topics;

public class TopicListDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public int? ParentTopicId { get; init; }
    public int SubjectId { get; init; }
}