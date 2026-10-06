using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonContentVocabularySeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.LessonContentVocabularies.AnyAsync())
            return;

        var vocabularies = await context.Vocabularies
            .ToDictionaryAsync(x => x.Code, x => x.Id);

        var lessonContents = await context.LessonContents
            .OrderBy(x => x.LessonId)
            .ThenBy(x => x.Order)
            .Take(10)
            .ToListAsync();

        var lessonContentVocabularies = new[]
        {
            new LessonContentVocabulary(lessonContents[0].Id, vocabularies["cell"]),
            new LessonContentVocabulary(lessonContents[1].Id, vocabularies["cell"]),
            new LessonContentVocabulary(lessonContents[2].Id, vocabularies["nucleus"]),
            new LessonContentVocabulary(lessonContents[3].Id, vocabularies["membrane"]),
            new LessonContentVocabulary(lessonContents[4].Id, vocabularies["membrane"]),
            new LessonContentVocabulary(lessonContents[5].Id, vocabularies["cytoplasm"]),
            new LessonContentVocabulary(lessonContents[6].Id, vocabularies["organ"]),
            new LessonContentVocabulary(lessonContents[7].Id, vocabularies["tissue"]),
            new LessonContentVocabulary(lessonContents[8].Id, vocabularies["organ_system"]),
            new LessonContentVocabulary(lessonContents[9].Id, vocabularies["digestive_system"])
        };

        await context.LessonContentVocabularies
            .AddRangeAsync(lessonContentVocabularies);

        await context.SaveChangesAsync();
    }
}