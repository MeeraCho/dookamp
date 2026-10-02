using DooKamp.Domain.Entities.Quizzes;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Domain.Enums;

namespace DooKamp.Domain.Entities.Lessons;

public sealed class Lesson : Entity<int>
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
        Status = LessonStatus.Published;
    }

    public string Title { get; private set; } = string.Empty;

    public int TopicId { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public DateTime UpdatedAt { get; private set; }

    public LessonStatus Status { get; private set; }

    public DateTime? PublishedAt { get; private set; }
    
    // Navigation Properties    
	public Topic Topic { get; private set; } = null!;    

    public IReadOnlyCollection<LessonLocationGrade> LessonLocationGrades
		{ get; private set; } = new List<LessonLocationGrade>();

    public IReadOnlyCollection<LessonContent> LessonContents
        { get; private set; } = new List<LessonContent>();
		
    public IReadOnlyCollection<QuizQuestion> QuizQuestions
        { get; private set; } = new List<QuizQuestion>();        
}