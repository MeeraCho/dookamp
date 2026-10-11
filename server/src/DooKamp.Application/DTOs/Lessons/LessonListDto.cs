namespace DooKamp.Application.DTOs.Lessons;

public class LessonListDto
{
    public int Id { get; init; }

    public string Title { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string TopicName { get; init; } = string.Empty;
}