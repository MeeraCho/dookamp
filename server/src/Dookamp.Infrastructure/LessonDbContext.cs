using Dookamp.Domain.Entities;
using Dookamp.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;

namespace Dookamp.Infrastructure;

public sealed class LessonDbContext(DbContextOptions<LessonDbContext> options) : DbContext(options)
{
    public DbSet<Grade> Grades => Set<Grade>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<Lesson> Lessons => Set<Lesson>();
    public DbSet<LessonContent> LessonContents => Set<LessonContent>();
    public DbSet<LessonContentAudio> LessonContentAudio => Set<LessonContentAudio>();
    public DbSet<LessonContentLanguage> LessonContentLanguages => Set<LessonContentLanguage>();
    public DbSet<LessonContentMedia> LessonContentMedia => Set<LessonContentMedia>();
    public DbSet<LessonContentVocabulary> LessonContentVocabulary => Set<LessonContentVocabulary>();
    public DbSet<LessonLanguage> LessonLanguages => Set<LessonLanguage>();
    public DbSet<LessonLocationGrade> LessonLocationGrades => Set<LessonLocationGrade>();
    public DbSet<Location> Locations => Set<Location>();
    public DbSet<Media> Media => Set<Media>();
    public DbSet<QuizOption> QuizOptions => Set<QuizOption>();
    public DbSet<QuizOptionLanguage> QuizOptionLanguages => Set<QuizOptionLanguage>();
    public DbSet<QuizQuestion> QuizQuestions => Set<QuizQuestion>();
    public DbSet<QuizQuestionLanguage> QuizQuestionLanguages => Set<QuizQuestionLanguage>();
    public DbSet<QuestionType> QuestionTypes => Set<QuestionType>();
    public DbSet<Subject> Subjects => Set<Subject>();
    public DbSet<Topic> Topics => Set<Topic>();
    public DbSet<Vocabulary> Vocabulary => Set<Vocabulary>();
    public DbSet<VocabularyAudio> VocabularyAudio => Set<VocabularyAudio>();
    public DbSet<VocabularyLanguage> VocabularyLanguages => Set<VocabularyLanguage>();
    public DbSet<VocabularyMedia> VocabularyMedia => Set<VocabularyMedia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Location>().HasIndex(x => x.Code).IsUnique();
        modelBuilder.Entity<Location>().HasData(LocationSeedData.All);
        modelBuilder.Entity<Grade>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Grade>().HasData(GradeSeedData.All);
        modelBuilder.Entity<Language>().HasIndex(x => x.Code).IsUnique();
        modelBuilder.Entity<Language>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Language>().HasData(LanguageSeedData.All);
        modelBuilder.Entity<Subject>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<Subject>().HasData(SubjectSeedData.All);
        modelBuilder.Entity<QuestionType>().HasIndex(x => x.Name).IsUnique();
        modelBuilder.Entity<QuestionType>().HasData(QuestionTypeSeedData.All);
        modelBuilder.Entity<Topic>().HasData(TopicSeedData.All);
        modelBuilder.Entity<Lesson>().HasData(LessonSeedData.Lessons);
        modelBuilder.Entity<LessonLanguage>().HasData(LessonSeedData.Languages);
        modelBuilder.Entity<LessonContent>().HasData(LessonContentSeedData.Contents);
        modelBuilder.Entity<LessonContentLanguage>().HasData(LessonContentSeedData.Languages);
        modelBuilder.Entity<LessonContentLanguage>().HasData(LessonContentLanguageSeedData.AdditionalLanguages);
        modelBuilder.Entity<Vocabulary>().HasData(VocabularySeedData.Vocabulary);
        modelBuilder.Entity<VocabularyLanguage>().HasData(VocabularySeedData.Languages);
        modelBuilder.Entity<VocabularyLanguage>().HasData(VocabularyLanguageSeedData.AdditionalLanguages);
        modelBuilder.Entity<LessonContentVocabulary>().HasData(LessonContentVocabularySeedData.All);
        modelBuilder.Entity<QuizQuestion>().HasData(QuizQuestionSeedData.Questions);
        modelBuilder.Entity<QuizQuestionLanguage>().HasData(QuizQuestionSeedData.Languages);
        modelBuilder.Entity<QuizQuestionLanguage>().HasData(QuizQuestionLanguageAdditionalSeedData.All);
        modelBuilder.Entity<QuizOption>().HasData(QuizOptionSeedData.Options);
        modelBuilder.Entity<QuizOptionLanguage>().HasData(QuizOptionSeedData.Languages);
        modelBuilder.Entity<QuizOptionLanguage>().HasData(QuizOptionLanguageSeedData.AdditionalLanguages);

        modelBuilder.Entity<Topic>().HasIndex(x => new { x.SubjectId, x.Name }).IsUnique();
        modelBuilder.Entity<LessonLanguage>().HasIndex(x => new { x.LessonId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<LessonContent>().HasIndex(x => new { x.LessonId, x.SortOrder }).IsUnique();
        modelBuilder.Entity<LessonContentLanguage>().HasIndex(x => new { x.LessonContentId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<VocabularyLanguage>().HasIndex(x => new { x.VocabularyId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<LessonContentVocabulary>().HasIndex(x => new { x.LessonContentId, x.VocabularyId }).IsUnique();
        modelBuilder.Entity<LessonContentAudio>().HasIndex(x => new { x.LessonContentId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<VocabularyAudio>().HasIndex(x => new { x.VocabularyId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<QuizQuestion>().HasIndex(x => new { x.LessonId, x.SortOrder }).IsUnique();
        modelBuilder.Entity<QuizQuestionLanguage>().HasIndex(x => new { x.QuizQuestionId, x.LanguageId }).IsUnique();
        modelBuilder.Entity<QuizOption>().HasIndex(x => new { x.QuizQuestionId, x.SortOrder }).IsUnique();
        modelBuilder.Entity<QuizOptionLanguage>().HasIndex(x => new { x.QuizOptionId, x.LanguageId }).IsUnique();

        modelBuilder.Entity<LessonLocationGrade>()
            .HasIndex(x => new { x.LessonId, x.LocationId, x.GradeId })
            .IsUnique();
        modelBuilder.Entity<LessonLocationGrade>().HasData(LessonLocationGradeSeedData.All);

        modelBuilder.Entity<LessonContentMedia>()
            .HasKey(x => new { x.LessonContentId, x.MediaId });
        modelBuilder.Entity<VocabularyMedia>()
            .HasKey(x => new { x.VocabularyId, x.MediaId });

        modelBuilder.Entity<Topic>()
            .HasOne(x => x.ParentTopic)
            .WithMany(x => x.Children)
            .HasForeignKey(x => x.ParentTopicId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
