using DooKamp.Domain.Entities.Quizzes;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Domain.Enums;
using DooKamp.Domain.Entities.Topics;

namespace DooKamp.Domain.Entities.Lessons;

public sealed class Lesson : Entity<int>
{
    private Lesson() { }

    public Lesson(
    string title,
    string? description = null)
{
    Title = title;
    Description = description;
    CreatedAt = DateTime.UtcNow;
    UpdatedAt = DateTime.UtcNow;
    Status = LessonStatus.Published;
}

    public string Title { get; private set; } = string.Empty;

    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public LessonStatus Status { get; private set; }

    public DateTime? PublishedAt { get; private set; }
    
    // Navigation Properties     
    public IReadOnlyCollection<LessonContent> LessonContents
        { get; private set; } = new List<LessonContent>();
		
    public IReadOnlyCollection<QuizQuestion> QuizQuestions
        { get; private set; } = new List<QuizQuestion>();  
    
    public IReadOnlyCollection<TopicLesson> TopicLessons
        { get; private set; } = new List<TopicLesson>();
}

