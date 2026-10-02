using DooKamp.Domain.Entities.Vocabs;
using DooKamp.Domain.Entities.Quizzes;
using DooKamp.Domain.Entities.Lessons;
using DooKamp.Domain.Entities.Audio;
namespace DooKamp.Domain.Entities.Languages;

public sealed class Language : Entity<int>
{
    private Language() { }

    public Language(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;
    
    // Navigation Properties
    public IReadOnlyCollection<LessonContentLanguage> LessonContentLanguages
        { get; private set; } = new List<LessonContentLanguage>();

    public IReadOnlyCollection<VocabularyLanguage> VocabularyLanguages
        { get; private set; } = new List<VocabularyLanguage>();

    public IReadOnlyCollection<LessonContentAudio> LessonContentAudios
        { get; private set; } = new List<LessonContentAudio>();

    public IReadOnlyCollection<VocabularyAudio> VocabularyAudios
        { get; private set; } = new List<VocabularyAudio>(); 
        
    public IReadOnlyCollection<QuizQuestionLanguage> QuizQuestionLanguages
        { get; private set; } = new List<QuizQuestionLanguage>();

    public IReadOnlyCollection<QuizOptionLanguage> QuizOptionLanguages
        { get; private set; } = new List<QuizOptionLanguage>();   
}