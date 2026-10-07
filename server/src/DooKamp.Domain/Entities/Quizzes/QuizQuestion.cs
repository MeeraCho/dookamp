using DooKamp.Domain.Entities.Lessons;

namespace DooKamp.Domain.Entities.Quizzes;

public sealed class QuizQuestion : Entity<int>
{
    private QuizQuestion() { }

    public QuizQuestion(
        int? lessonId,
        int? lessonContentId,
        int questionTypeId,
        int? order)
    {
        LessonId = lessonId;
        LessonContentId = lessonContentId;
        QuestionTypeId = questionTypeId;
        Order = order;
    }

    public int? LessonId { get; private set; }

    public int? LessonContentId { get; private set; }

    public int QuestionTypeId { get; private set; }

    public int? Order { get; private set; }

    // Navigation Properties
    public Lesson Lesson { get; private set; } = null!;

    public LessonContent? LessonContent { get; private set; }

    public QuestionType QuestionType { get; private set; } = null!;

    public IReadOnlyCollection<QuizQuestionLanguage> Languages
        { get; private set; } = new List<QuizQuestionLanguage>();

    public IReadOnlyCollection<QuizOption> Options
        { get; private set; } = new List<QuizOption>();
        
    public IReadOnlyCollection<QuizQuestionAnswer> Answers
        { get; private set; } = new List<QuizQuestionAnswer>();    
}