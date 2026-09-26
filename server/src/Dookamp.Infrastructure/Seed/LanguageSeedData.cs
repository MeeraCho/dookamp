namespace Dookamp.Infrastructure.Seed;

public sealed class LanguageSeed
{
    public int Id { get; init; }
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}

public static class LanguageSeedData
{
    public static IReadOnlyList<LanguageSeed> All { get; } =
    [
        new() { Id = 1, Code = "en", Name = "English" },
        new() { Id = 2, Code = "ko", Name = "Korean" },
        new() { Id = 3, Code = "es", Name = "Spanish" },
        new() { Id = 4, Code = "zh-CN", Name = "Mandarin Chinese (Simplified)" },
        new() { Id = 5, Code = "ar", Name = "Arabic" },
        new() { Id = 6, Code = "bn", Name = "Bengali" },
        new() { Id = 7, Code = "de", Name = "German" },
        new() { Id = 8, Code = "fa", Name = "Persian" },
        new() { Id = 9, Code = "fil", Name = "Filipino" },
        new() { Id = 10, Code = "fr", Name = "French" },
        new() { Id = 11, Code = "hi", Name = "Hindi" },
        new() { Id = 12, Code = "id", Name = "Indonesian" },
        new() { Id = 13, Code = "it", Name = "Italian" },
        new() { Id = 14, Code = "ja", Name = "Japanese" },
        new() { Id = 15, Code = "ms", Name = "Malay" },
        new() { Id = 16, Code = "pt", Name = "Portuguese" },
        new() { Id = 17, Code = "ru", Name = "Russian" },
        new() { Id = 18, Code = "th", Name = "Thai" },
        new() { Id = 19, Code = "tr", Name = "Turkish" },
        new() { Id = 20, Code = "vi", Name = "Vietnamese" },
        new() { Id = 21, Code = "zh-TW", Name = "Mandarin Chinese (Taiwan)" },
        new() { Id = 22, Code = "yue-HK", Name = "Cantonese (Hong Kong)" }
    ];
}
