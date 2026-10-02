using DooKamp.Domain.Entities.Vocabs;
using DooKamp.Domain.Entities.Media;
using DooKamp.Domain.Entities.Audio;
using DooKamp.Domain.Entities.Quizzes;


namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonContent : Entity<int>
{
    private LessonContent() { }

    public LessonContent(
        int lessonId,
        int order)
    {
        LessonId = lessonId;
        Order = order;
    }

    public int LessonId { get; private set; }

    public int Order { get; private set; }
    
    // Navigation Properties
    public Lesson Lesson { get; private set; } = null!;

    public IReadOnlyCollection<LessonContentLanguage> Languages
        { get; private set; } = new List<LessonContentLanguage>();

    public IReadOnlyCollection<LessonContentVocabulary> Vocabularies
        { get; private set; } = new List<LessonContentVocabulary>();

    public IReadOnlyCollection<LessonContentMedia> MediaItems
        { get; private set; } = new List<LessonContentMedia>();

    public IReadOnlyCollection<LessonContentAudio> Audios
        { get; private set; } = new List<LessonContentAudio>(); 
		
    public IReadOnlyCollection<QuizQuestion> QuizQuestions
        { get; private set; } = new List<QuizQuestion>();            
}