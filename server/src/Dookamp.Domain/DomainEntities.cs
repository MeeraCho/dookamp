#pragma warning disable CS8618

namespace Dookamp.Domain.Entities;

public abstract class Entity
{
    public int Id { get; protected set; }
}

public sealed class Location : Entity
{
    private Location() { }

    public Location(string name, string code, string country)
    {
        Name = name;
        Code = code;
        Country = country;
    }

    public string Name { get; private set; }
    public string Code { get; private set; }
    public string Country { get; private set; }
}

public sealed class Grade : Entity
{
    private Grade() { }

    public Grade(string name) => Name = name;

    public string Name { get; private set; }
}

public sealed class Language : Entity
{
    private Language() { }

    public Language(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; }
    public string Name { get; private set; }
}

public sealed class Subject : Entity
{
    private Subject() { }

    public Subject(string name) => Name = name;

    public string Name { get; private set; }
    public List<Topic> Topics { get; } = [];
}

public sealed class Topic : Entity
{
    private Topic() { }

    public Topic(string name, Subject subject, string? description = null, Topic? parent = null)
    {
        Name = name;
        Subject = subject;
        SubjectId = subject.Id;
        Description = description;
        ParentTopic = parent;
        ParentTopicId = parent?.Id;
    }

    public string Name { get; private set; }
    public int? ParentTopicId { get; private set; }
    public Topic? ParentTopic { get; private set; }
    public int SubjectId { get; private set; }
    public Subject Subject { get; private set; }
    public string? Description { get; private set; }
    public List<Topic> Children { get; } = [];
    public List<Lesson> Lessons { get; } = [];
}

public sealed class Lesson : Entity
{
    private Lesson() { }

    public Lesson(Topic topic)
    {
        Topic = topic;
        TopicId = topic.Id;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = CreatedAt;
    }

    public int TopicId { get; private set; }
    public Topic Topic { get; private set; }
    public bool IsPublished { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public List<LessonLanguage> Languages { get; } = [];
    public List<LessonContent> Contents { get; } = [];
    public List<LessonLocationGrade> LocationGrades { get; } = [];
    public List<QuizQuestion> Questions { get; } = [];

    public void Publish()
    {
        IsPublished = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Unpublish()
    {
        IsPublished = false;
        UpdatedAt = DateTime.UtcNow;
    }
}

public sealed class LessonLanguage : Entity
{
    private LessonLanguage() { }

    public LessonLanguage(Lesson lesson, Language language, string name, string? description = null)
    {
        Lesson = lesson;
        LessonId = lesson.Id;
        Language = language;
        LanguageId = language.Id;
        Name = name;
        Description = description;
    }

    public int LessonId { get; private set; }
    public Lesson Lesson { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string Name { get; private set; }
    public string? Description { get; private set; }
}

public sealed class LessonContent : Entity
{
    private LessonContent() { }

    public LessonContent(Lesson lesson, int sortOrder)
    {
        Lesson = lesson;
        LessonId = lesson.Id;
        SortOrder = sortOrder;
    }

    public int LessonId { get; private set; }
    public Lesson Lesson { get; private set; }
    public int SortOrder { get; private set; }
    public List<LessonContentLanguage> Languages { get; } = [];
    public List<LessonContentVocabulary> Vocabulary { get; } = [];
    public List<LessonContentMedia> Media { get; } = [];
    public List<LessonContentAudio> Audio { get; } = [];
}

public sealed class LessonContentLanguage : Entity
{
    private LessonContentLanguage() { }

    public LessonContentLanguage(LessonContent content, Language language, string text)
    {
        LessonContent = content;
        LessonContentId = content.Id;
        Language = language;
        LanguageId = language.Id;
        Text = text;
    }

    public int LessonContentId { get; private set; }
    public LessonContent LessonContent { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string Text { get; private set; }
}

public sealed class Vocabulary : Entity
{
    private Vocabulary() { }

    public List<VocabularyLanguage> Languages { get; } = [];
    public List<LessonContentVocabulary> Contents { get; } = [];
    public List<VocabularyMedia> Media { get; } = [];
    public List<VocabularyAudio> Audio { get; } = [];
}

public sealed class VocabularyLanguage : Entity
{
    private VocabularyLanguage() { }

    public VocabularyLanguage(Vocabulary vocabulary, Language language, string word, string definition)
    {
        Vocabulary = vocabulary;
        VocabularyId = vocabulary.Id;
        Language = language;
        LanguageId = language.Id;
        Word = word;
        Definition = definition;
    }

    public int VocabularyId { get; private set; }
    public Vocabulary Vocabulary { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string Word { get; private set; }
    public string Definition { get; private set; }
}

public sealed class LessonContentVocabulary : Entity
{
    private LessonContentVocabulary() { }

    public LessonContentVocabulary(LessonContent content, Vocabulary vocabulary)
    {
        LessonContent = content;
        LessonContentId = content.Id;
        Vocabulary = vocabulary;
        VocabularyId = vocabulary.Id;
    }

    public int LessonContentId { get; private set; }
    public LessonContent LessonContent { get; private set; }
    public int VocabularyId { get; private set; }
    public Vocabulary Vocabulary { get; private set; }
}

public sealed class Media : Entity
{
    private Media() { }

    public Media(string mediaType, string url, string? altText = null)
    {
        MediaType = mediaType;
        Url = url;
        AltText = altText;
    }

    public string MediaType { get; private set; }
    public string Url { get; private set; }
    public string? AltText { get; private set; }
}

public sealed class LessonContentMedia : Entity
{
    private LessonContentMedia() { }

    public LessonContentMedia(LessonContent content, Media media)
    {
        LessonContent = content;
        LessonContentId = content.Id;
        Media = media;
        MediaId = media.Id;
    }

    public int LessonContentId { get; private set; }
    public LessonContent LessonContent { get; private set; }
    public int MediaId { get; private set; }
    public Media Media { get; private set; }
}

public sealed class VocabularyMedia : Entity
{
    private VocabularyMedia() { }

    public VocabularyMedia(Vocabulary vocabulary, Media media)
    {
        Vocabulary = vocabulary;
        VocabularyId = vocabulary.Id;
        Media = media;
        MediaId = media.Id;
    }

    public int VocabularyId { get; private set; }
    public Vocabulary Vocabulary { get; private set; }
    public int MediaId { get; private set; }
    public Media Media { get; private set; }
}

public sealed class LessonContentAudio : Entity
{
    private LessonContentAudio() { }

    public LessonContentAudio(LessonContent content, Language language, string audioUrl)
    {
        LessonContent = content;
        LessonContentId = content.Id;
        Language = language;
        LanguageId = language.Id;
        AudioUrl = audioUrl;
    }

    public int LessonContentId { get; private set; }
    public LessonContent LessonContent { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string AudioUrl { get; private set; }
}

public sealed class VocabularyAudio : Entity
{
    private VocabularyAudio() { }

    public VocabularyAudio(Vocabulary vocabulary, Language language, string audioUrl)
    {
        Vocabulary = vocabulary;
        VocabularyId = vocabulary.Id;
        Language = language;
        LanguageId = language.Id;
        AudioUrl = audioUrl;
    }

    public int VocabularyId { get; private set; }
    public Vocabulary Vocabulary { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string AudioUrl { get; private set; }
}

public sealed class LessonLocationGrade : Entity
{
    private LessonLocationGrade() { }

    public LessonLocationGrade(Lesson lesson, Location location, Grade grade)
    {
        Lesson = lesson;
        LessonId = lesson.Id;
        Location = location;
        LocationId = location.Id;
        Grade = grade;
        GradeId = grade.Id;
    }

    public int LessonId { get; private set; }
    public Lesson Lesson { get; private set; }
    public int LocationId { get; private set; }
    public Location Location { get; private set; }
    public int GradeId { get; private set; }
    public Grade Grade { get; private set; }
}

public sealed class QuestionType : Entity
{
    private QuestionType() { }

    public QuestionType(string name) => Name = name;

    public string Name { get; private set; }
}

public sealed class QuizQuestion : Entity
{
    private QuizQuestion() { }

    public QuizQuestion(Lesson lesson, QuestionType questionType, int sortOrder)
    {
        Lesson = lesson;
        LessonId = lesson.Id;
        QuestionType = questionType;
        QuestionTypeId = questionType.Id;
        SortOrder = sortOrder;
    }

    public int LessonId { get; private set; }
    public Lesson Lesson { get; private set; }
    public int QuestionTypeId { get; private set; }
    public QuestionType QuestionType { get; private set; }
    public int SortOrder { get; private set; }
    public List<QuizQuestionLanguage> Languages { get; } = [];
    public List<QuizOption> Options { get; } = [];
}

public sealed class QuizQuestionLanguage : Entity
{
    private QuizQuestionLanguage() { }

    public QuizQuestionLanguage(QuizQuestion question, Language language, string questionText)
    {
        QuizQuestion = question;
        QuizQuestionId = question.Id;
        Language = language;
        LanguageId = language.Id;
        QuestionText = questionText;
    }

    public int QuizQuestionId { get; private set; }
    public QuizQuestion QuizQuestion { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string QuestionText { get; private set; }
}

public sealed class QuizOption : Entity
{
    private QuizOption() { }

    public QuizOption(QuizQuestion question, bool isCorrect, int sortOrder)
    {
        QuizQuestion = question;
        QuizQuestionId = question.Id;
        IsCorrect = isCorrect;
        SortOrder = sortOrder;
    }

    public int QuizQuestionId { get; private set; }
    public QuizQuestion QuizQuestion { get; private set; }
    public bool IsCorrect { get; private set; }
    public int SortOrder { get; private set; }
    public List<QuizOptionLanguage> Languages { get; } = [];
}

public sealed class QuizOptionLanguage : Entity
{
    private QuizOptionLanguage() { }

    public QuizOptionLanguage(QuizOption option, Language language, string text)
    {
        QuizOption = option;
        QuizOptionId = option.Id;
        Language = language;
        LanguageId = language.Id;
        Text = text;
    }

    public int QuizOptionId { get; private set; }
    public QuizOption QuizOption { get; private set; }
    public int LanguageId { get; private set; }
    public Language Language { get; private set; }
    public string Text { get; private set; }
}

#pragma warning restore CS8618
