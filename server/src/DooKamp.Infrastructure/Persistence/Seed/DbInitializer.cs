using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class DbInitializer
{
    public static async Task InitializeAsync(
        DooKampDbContext context)
    {
        await context.Database.MigrateAsync();

        // Seed 
        await LocationSeed.SeedAsync(context);
        await GradeSeed.SeedAsync(context);
        await LanguageSeed.SeedAsync(context);
        await SubjectSeed.SeedAsync(context);
        await TopicSeed.SeedAsync(context);
        await LessonSeed.SeedAsync(context);
        await LessonTopicSeed.SeedAsync(context);
        await LessonLocationGradeSeed.SeedAsync(context);
        await LessonContentSeed.SeedAsync(context);
        await LessonContentLanguageSeed.SeedAsync(context);
        await VocabularySeed.SeedAsync(context);
        await VocabularyLanguageSeed.SeedAsync(context);
        await LessonContentVocabularySeed.SeedAsync(context);
    }
}