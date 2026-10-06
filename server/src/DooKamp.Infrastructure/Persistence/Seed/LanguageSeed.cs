using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Domain.Entities.Languages;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LanguageSeed
{
    public static async Task SeedAsync(
        DooKampDbContext context)
    {
        if (await context.Languages.AnyAsync())
            return;

        var languages = new[]
        {
            new Language("en", "English"),
            new Language("ko", "Korean"),

            new Language("ar", "Arabic"),
            new Language("bn", "Bengali"),
            new Language("de", "German"),
            new Language("fa", "Persian"),
            new Language("fil", "Filipino"),
            new Language("fr", "French"),
            new Language("hi", "Hindi"),
            new Language("id", "Indonesian"),
            new Language("it", "Italian"),
            new Language("ja", "Japanese"),
            new Language("ms", "Malay"),
            new Language("pt-BR", "Portuguese (Brazil)"),
            new Language("pt-PT", "Portuguese (Portugal)"),            
            new Language("ru", "Russian"),
            new Language("es", "Spanish"),
            new Language("th", "Thai"),
            new Language("tr", "Turkish"),
            new Language("vi", "Vietnamese"),            

            // Chinese
            new Language("zh-CN", "Mandarin Chinese (Simplified)"),
            new Language("zh-TW", "Mandarin Chinese (Traditional)"),
            new Language("yue-HK", "Cantonese (Hong Kong)"),            
        };

        await context.Languages.AddRangeAsync(languages);
        await context.SaveChangesAsync();
    }
}