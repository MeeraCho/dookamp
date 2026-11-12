namespace DooKamp.Application.DTOs.Topics;

public class TopicLessonDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string? Description { get; init; }
}