namespace Dookamp.Infrastructure.Seed;

public sealed class LessonContentSeed
{
    public int Id { get; init; }
    public int LessonId { get; init; }
    public int SortOrder { get; init; }
}

public sealed class LessonContentLanguageSeed
{
    public int Id { get; init; }
    public int LessonContentId { get; init; }
    public int LanguageId { get; init; }
    public string Text { get; init; } = string.Empty;
}

public static class LessonContentSeedData
{
    public static IReadOnlyList<LessonContentSeed> Contents { get; } =
    [
        new() { Id = 1, LessonId = 1, SortOrder = 1 },
        new() { Id = 2, LessonId = 1, SortOrder = 2 },
        new() { Id = 3, LessonId = 1, SortOrder = 3 },
        new() { Id = 4, LessonId = 1, SortOrder = 4 },
        new() { Id = 5, LessonId = 1, SortOrder = 5 },
        new() { Id = 6, LessonId = 1, SortOrder = 6 },
        new() { Id = 7, LessonId = 1, SortOrder = 7 },
        new() { Id = 8, LessonId = 1, SortOrder = 8 },
        new() { Id = 9, LessonId = 1, SortOrder = 9 },
        new() { Id = 10, LessonId = 1, SortOrder = 10 },
        new() { Id = 11, LessonId = 1, SortOrder = 11 },
        new() { Id = 12, LessonId = 1, SortOrder = 12 },
        new() { Id = 13, LessonId = 1, SortOrder = 13 },
        new() { Id = 14, LessonId = 1, SortOrder = 14 },
        new() { Id = 15, LessonId = 1, SortOrder = 15 },
        new() { Id = 16, LessonId = 1, SortOrder = 16 },
        new() { Id = 17, LessonId = 1, SortOrder = 17 },
        new() { Id = 18, LessonId = 1, SortOrder = 18 },
        new() { Id = 19, LessonId = 2, SortOrder = 1 },
        new() { Id = 20, LessonId = 2, SortOrder = 2 },
        new() { Id = 21, LessonId = 2, SortOrder = 3 },
        new() { Id = 22, LessonId = 2, SortOrder = 4 },
        new() { Id = 23, LessonId = 2, SortOrder = 5 },
        new() { Id = 24, LessonId = 2, SortOrder = 6 },
        new() { Id = 25, LessonId = 2, SortOrder = 7 },
        new() { Id = 26, LessonId = 2, SortOrder = 8 },
        new() { Id = 27, LessonId = 2, SortOrder = 9 },
        new() { Id = 28, LessonId = 2, SortOrder = 10 },
        new() { Id = 29, LessonId = 2, SortOrder = 11 },
        new() { Id = 30, LessonId = 2, SortOrder = 12 },
        new() { Id = 31, LessonId = 2, SortOrder = 13 },
        new() { Id = 32, LessonId = 2, SortOrder = 14 }
    ];

    public static IReadOnlyList<LessonContentLanguageSeed> Languages { get; } =
    [
        new() { Id = 1, LessonContentId = 1, LanguageId = 1, Text = "Weather is what we feel when we go outside." },
        new() { Id = 2, LessonContentId = 2, LanguageId = 1, Text = "It includes things like temperature, precipitation, wind, humidity, cloudiness, atmospheric pressure, and sunshine." },
        new() { Id = 3, LessonContentId = 3, LanguageId = 1, Text = "Temperature is how hot or cold it is." },
        new() { Id = 4, LessonContentId = 4, LanguageId = 1, Text = "We use thermometers to measure it." },
        new() { Id = 5, LessonContentId = 5, LanguageId = 1, Text = "Precipitation is water that falls from the sky." },
        new() { Id = 6, LessonContentId = 6, LanguageId = 1, Text = "This includes rain, snow, sleet, and hail." },
        new() { Id = 7, LessonContentId = 7, LanguageId = 1, Text = "Wind is moving air." },
        new() { Id = 8, LessonContentId = 8, LanguageId = 1, Text = "We measure wind speed with an instrument called an anemometer." },
        new() { Id = 9, LessonContentId = 9, LanguageId = 1, Text = "Humidity tells us how much water is in the air." },
        new() { Id = 10, LessonContentId = 10, LanguageId = 1, Text = "A hygrometer is used to measure it." },
        new() { Id = 11, LessonContentId = 11, LanguageId = 1, Text = "Cloudiness tells us how many clouds are in the sky." },
        new() { Id = 12, LessonContentId = 12, LanguageId = 1, Text = "Atmospheric pressure is how heavy the air is." },
        new() { Id = 13, LessonContentId = 13, LanguageId = 1, Text = "Low pressure can mean bad weather, and high pressure can mean good weather." },
        new() { Id = 14, LessonContentId = 14, LanguageId = 1, Text = "Sunshine is how much sunlight is reaching us." },
        new() { Id = 15, LessonContentId = 15, LanguageId = 1, Text = "It can change temperature and is measured with a sunshine recorder." },
        new() { Id = 16, LessonContentId = 16, LanguageId = 1, Text = "All these things work together to make our weather." },
        new() { Id = 17, LessonContentId = 17, LanguageId = 1, Text = "Weather can change quickly." },
        new() { Id = 18, LessonContentId = 18, LanguageId = 1, Text = "It is good to check the forecast before planning your day." },
        new() { Id = 19, LessonContentId = 19, LanguageId = 1, Text = "The circulatory system is the movement of blood through the body." },
        new() { Id = 20, LessonContentId = 20, LanguageId = 1, Text = "Blood carries nutrients to the cells in our body." },
        new() { Id = 21, LessonContentId = 21, LanguageId = 1, Text = "The main organs in the circulatory system are blood vessels and the heart." },
        new() { Id = 22, LessonContentId = 22, LanguageId = 1, Text = "There are three types of blood vessels: arteries, veins, and capillaries." },
        new() { Id = 23, LessonContentId = 23, LanguageId = 1, Text = "Arteries carry oxygenated blood away from the heart to the rest of the body." },
        new() { Id = 24, LessonContentId = 24, LanguageId = 1, Text = "Veins carry oxygen-depleted blood back to the heart." },
        new() { Id = 25, LessonContentId = 25, LanguageId = 1, Text = "Capillaries are tiny blood vessels that connect arteries to veins." },
        new() { Id = 26, LessonContentId = 26, LanguageId = 1, Text = "The cells in our body need oxygen to survive." },
        new() { Id = 27, LessonContentId = 27, LanguageId = 1, Text = "The heart pumps blood through the lungs, where oxygen is added to the blood." },
        new() { Id = 28, LessonContentId = 28, LanguageId = 1, Text = "Oxygen-rich blood travels away from the heart through arteries." },
        new() { Id = 29, LessonContentId = 29, LanguageId = 1, Text = "Used blood travels back to the heart through veins." },
        new() { Id = 30, LessonContentId = 30, LanguageId = 1, Text = "The heart is a muscle that acts like two pumps." },
        new() { Id = 31, LessonContentId = 31, LanguageId = 1, Text = "The right side pumps blood to the lungs to get oxygen." },
        new() { Id = 32, LessonContentId = 32, LanguageId = 1, Text = "The left side pumps oxygen-rich blood to the body." }
    ];
}
