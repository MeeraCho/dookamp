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
    }
}