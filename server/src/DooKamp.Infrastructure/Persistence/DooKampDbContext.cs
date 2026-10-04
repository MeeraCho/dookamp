using DooKamp.Domain.Entities.Audio;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Domain.Entities.Languages;
using DooKamp.Domain.Entities.Lessons;
using DooKamp.Domain.Entities.Media;
using DooKamp.Domain.Entities.Quizzes;
using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Data;

public class DooKampDbContext : DbContext
{
    // EF Core에 사용할 DB 연결 설정을 받음
    public DooKampDbContext(DbContextOptions<DooKampDbContext> options)
        : base(options)
    {
    }

	// DB에서 관리할 Entity들 DbSet으로 등록
    // Audio
    public DbSet<LessonContentAudio> LessonContentAudios => Set<LessonContentAudio>();
    public DbSet<VocabularyAudio> VocabularyAudios => Set<VocabularyAudio>();
    
    // Curriculum
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Topic> Topics => Set<Topic>();
    
    // Languages
    public DbSet<Language> Languages => Set<Language>();
    
    // Lessons
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<LessonContent> LessonContents => Set<LessonContent>();
    public DbSet<LessonContentLanguage> LessonContentLanguages => Set<LessonContentLanguage>();
    public DbSet<LessonLocationGrade> LessonLocationGrades => Set<LessonLocationGrade>();
    
    // Media
    public DbSet<LessonContentMedia> LessonContentMedias => Set<LessonContentMedia>();
    public DbSet<Media> Medias => Set<Media>();
    public DbSet<VocabularyMedia> VocabularyMedias => Set<VocabularyMedia>();

    // Quizzes
    public DbSet<QuestionType> QuestionTypes => Set<QuestionType>();
    public DbSet<QuizOption> QuizOptions => Set<QuizOption>();
    public DbSet<QuizOptionLanguage> QuizOptionLanguages => Set<QuizOptionLanguage>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<QuizQuestionLanguage> QuizQuestionLanguages => Set<QuizQuestionLanguage>();		
    
    // Vocabulary
    public DbSet<LessonContentVocabulary> LessonContentVocabularies => Set<LessonContentVocabulary>();
    public DbSet<Vocabulary> Vocabularies => Set<Vocabulary>();
    public DbSet<VocabularyLanguage> VocabularyLanguages => Set<VocabularyLanguage>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DooKampDbContext).Assembly);
    }
}