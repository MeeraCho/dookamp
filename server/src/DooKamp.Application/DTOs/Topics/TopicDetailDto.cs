namespace DooKamp.Application.DTOs.Topics;

public class TopicDetailDto
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string? Description { get; init; }

    public int? ParentTopicId { get; init; }

    public int SubjectId { get; init; }

    public IReadOnlyList<TopicListDto> ChildTopics { get; init; } = [];

    public IReadOnlyList<TopicLessonDto> Lessons { get; init; } = [];
}