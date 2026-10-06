using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class VocabularySeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.Vocabularies.AnyAsync())
            return;

        var vocabularies = new[]
        {
            new Vocabulary("cell"),
            new Vocabulary("nucleus"),
            new Vocabulary("membrane"),
            new Vocabulary("cytoplasm"),
            new Vocabulary("organ"),
            new Vocabulary("tissue"),
            new Vocabulary("organ_system"),
            new Vocabulary("digestive_system"),
            new Vocabulary("respiratory_system"),
            new Vocabulary("circulatory_system")
        };

        await context.Vocabularies.AddRangeAsync(vocabularies);
        await context.SaveChangesAsync();
    }
}