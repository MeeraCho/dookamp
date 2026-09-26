namespace Dookamp.Infrastructure.Seed;

public sealed class VocabularySeed
{
    public int Id { get; init; }
}

public sealed class VocabularyLanguageSeed
{
    public int Id { get; init; }
    public int VocabularyId { get; init; }
    public int LanguageId { get; init; }
    public string Word { get; init; } = string.Empty;
    public string Definition { get; init; } = string.Empty;
}

public static class VocabularySeedData
{
    public static IReadOnlyList<VocabularySeed> Vocabulary { get; } =
    [
        new() { Id = 1 }, new() { Id = 2 }, new() { Id = 3 }, new() { Id = 4 },
        new() { Id = 5 }, new() { Id = 6 }, new() { Id = 7 }, new() { Id = 8 },
        new() { Id = 9 }, new() { Id = 10 }, new() { Id = 11 }, new() { Id = 12 },
        new() { Id = 13 }, new() { Id = 14 }, new() { Id = 15 }, new() { Id = 16 },
        new() { Id = 17 }, new() { Id = 18 }, new() { Id = 19 }, new() { Id = 20 },
        new() { Id = 21 }, new() { Id = 22 }, new() { Id = 23 }, new() { Id = 24 },
        new() { Id = 25 }, new() { Id = 26 }, new() { Id = 27 }, new() { Id = 28 },
        new() { Id = 29 }, new() { Id = 30 }, new() { Id = 31 }, new() { Id = 32 },
        new() { Id = 33 }, new() { Id = 34 }, new() { Id = 35 }, new() { Id = 36 },
        new() { Id = 37 }, new() { Id = 38 }
    ];

    public static IReadOnlyList<VocabularyLanguageSeed> Languages { get; } =
    [
        new() { Id = 1, VocabularyId = 1, LanguageId = 1, Word = "Weather", Definition = "What the air and sky are like at a particular time and place." },
        new() { Id = 2, VocabularyId = 2, LanguageId = 1, Word = "Temperature", Definition = "How hot or cold something is." },
        new() { Id = 3, VocabularyId = 3, LanguageId = 1, Word = "Precipitation", Definition = "Water that falls from the sky, such as rain, snow, sleet, or hail." },
        new() { Id = 4, VocabularyId = 4, LanguageId = 1, Word = "Rain", Definition = "Water that falls from clouds as drops." },
        new() { Id = 5, VocabularyId = 5, LanguageId = 1, Word = "Snow", Definition = "Frozen water that falls from clouds as soft white flakes." },
        new() { Id = 6, VocabularyId = 6, LanguageId = 1, Word = "Sleet", Definition = "Small pieces of ice that fall from the sky." },
        new() { Id = 7, VocabularyId = 7, LanguageId = 1, Word = "Hail", Definition = "Balls or pieces of ice that fall from clouds." },
        new() { Id = 8, VocabularyId = 8, LanguageId = 1, Word = "Wind", Definition = "Moving air." },
        new() { Id = 9, VocabularyId = 9, LanguageId = 1, Word = "Anemometer", Definition = "An instrument used to measure wind speed." },
        new() { Id = 10, VocabularyId = 10, LanguageId = 1, Word = "Humidity", Definition = "The amount of water vapor in the air." },
        new() { Id = 11, VocabularyId = 11, LanguageId = 1, Word = "Hygrometer", Definition = "An instrument used to measure humidity." },
        new() { Id = 12, VocabularyId = 12, LanguageId = 1, Word = "Cloudiness", Definition = "How many clouds are in the sky." },
        new() { Id = 13, VocabularyId = 13, LanguageId = 1, Word = "Cloud", Definition = "A group of tiny water droplets or ice crystals in the sky." },
        new() { Id = 14, VocabularyId = 14, LanguageId = 1, Word = "Atmospheric Pressure", Definition = "The force caused by the weight of air pressing down on an area." },
        new() { Id = 15, VocabularyId = 15, LanguageId = 1, Word = "Sunshine", Definition = "Light from the Sun reaching Earth." },
        new() { Id = 16, VocabularyId = 16, LanguageId = 1, Word = "Sunlight", Definition = "Light and energy that come from the Sun." },
        new() { Id = 17, VocabularyId = 17, LanguageId = 1, Word = "Sunshine Recorder", Definition = "An instrument used to measure the amount of sunshine." },
        new() { Id = 18, VocabularyId = 18, LanguageId = 1, Word = "Forecast", Definition = "A prediction of what the weather will be like." },
        new() { Id = 19, VocabularyId = 19, LanguageId = 1, Word = "Circulatory System", Definition = "The system that moves blood around the body." },
        new() { Id = 20, VocabularyId = 20, LanguageId = 1, Word = "Blood", Definition = "A fluid that carries oxygen and nutrients through the body." },
        new() { Id = 21, VocabularyId = 21, LanguageId = 1, Word = "Nutrient", Definition = "A substance that the body needs to grow and stay healthy." },
        new() { Id = 22, VocabularyId = 22, LanguageId = 1, Word = "Cell", Definition = "The smallest basic unit that makes up a living thing." },
        new() { Id = 23, VocabularyId = 23, LanguageId = 1, Word = "Blood Vessel", Definition = "A tube that carries blood through the body." },
        new() { Id = 24, VocabularyId = 24, LanguageId = 1, Word = "Heart", Definition = "A muscular organ that pumps blood through the body." },
        new() { Id = 25, VocabularyId = 25, LanguageId = 1, Word = "Artery", Definition = "A blood vessel that carries blood away from the heart." },
        new() { Id = 26, VocabularyId = 26, LanguageId = 1, Word = "Vein", Definition = "A blood vessel that carries blood back to the heart." },
        new() { Id = 27, VocabularyId = 27, LanguageId = 1, Word = "Capillary", Definition = "A tiny blood vessel that connects arteries and veins." },
        new() { Id = 28, VocabularyId = 28, LanguageId = 1, Word = "Oxygen", Definition = "A gas that cells need to survive." },
        new() { Id = 29, VocabularyId = 29, LanguageId = 1, Word = "Oxygenated Blood", Definition = "Blood that contains oxygen." },
        new() { Id = 30, VocabularyId = 30, LanguageId = 1, Word = "Oxygen-depleted Blood", Definition = "Blood that has given up much of its oxygen." },
        new() { Id = 31, VocabularyId = 31, LanguageId = 1, Word = "Lung", Definition = "An organ where oxygen enters the blood and carbon dioxide leaves it." },
        new() { Id = 32, VocabularyId = 32, LanguageId = 1, Word = "Pump", Definition = "A device or action that moves a fluid from one place to another." },
        new() { Id = 33, VocabularyId = 33, LanguageId = 1, Word = "Atrium", Definition = "An upper chamber of the heart where blood enters." },
        new() { Id = 34, VocabularyId = 34, LanguageId = 1, Word = "Ventricle", Definition = "A lower chamber of the heart that pumps blood out." },
        new() { Id = 35, VocabularyId = 35, LanguageId = 1, Word = "Aorta", Definition = "The main artery that carries blood away from the heart." },
        new() { Id = 36, VocabularyId = 36, LanguageId = 1, Word = "Tricuspid Valve", Definition = "A heart valve between the right atrium and right ventricle." },
        new() { Id = 37, VocabularyId = 37, LanguageId = 1, Word = "Pulmonary Vein", Definition = "A blood vessel that carries oxygen-rich blood from the lungs to the heart." },
        new() { Id = 38, VocabularyId = 38, LanguageId = 1, Word = "Pulmonary Artery", Definition = "A blood vessel that carries blood from the heart to the lungs." }
    ];
}
