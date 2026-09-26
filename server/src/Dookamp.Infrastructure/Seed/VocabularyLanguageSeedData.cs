namespace Dookamp.Infrastructure.Seed;

public static class VocabularyLanguageSeedData
{
    public static IReadOnlyList<VocabularyLanguageSeed> AdditionalLanguages { get; } =
    [
        new() { Id = 39, VocabularyId = 1, LanguageId = 2, Word = "날씨", Definition = "특정 시간과 장소에서의 공기와 하늘의 상태" },
        new() { Id = 40, VocabularyId = 1, LanguageId = 3, Word = "Tiempo", Definition = "Cómo están el aire y el cielo en un momento y lugar determinados." },
        new() { Id = 41, VocabularyId = 1, LanguageId = 4, Word = "天气", Definition = "某个时间和地点的空气和天空状况。" },
        new() { Id = 42, VocabularyId = 2, LanguageId = 2, Word = "온도", Definition = "어떤 것이 얼마나 덥거나 추운지를 나타내는 것" },
        new() { Id = 43, VocabularyId = 2, LanguageId = 3, Word = "Temperatura", Definition = "Qué tan caliente o frío está algo." },
        new() { Id = 44, VocabularyId = 2, LanguageId = 4, Word = "温度", Definition = "表示某物有多热或多冷。" },
        new() { Id = 45, VocabularyId = 3, LanguageId = 2, Word = "강수", Definition = "하늘에서 떨어지는 물" },
        new() { Id = 46, VocabularyId = 3, LanguageId = 3, Word = "Precipitación", Definition = "Agua que cae del cielo." },
        new() { Id = 47, VocabularyId = 3, LanguageId = 4, Word = "降水", Definition = "从天空中落下的水。" },
        new() { Id = 48, VocabularyId = 4, LanguageId = 2, Word = "비", Definition = "구름에서 물방울 형태로 떨어지는 물" },
        new() { Id = 49, VocabularyId = 4, LanguageId = 3, Word = "Lluvia", Definition = "Agua que cae de las nubes en forma de gotas." },
        new() { Id = 50, VocabularyId = 4, LanguageId = 4, Word = "雨", Definition = "以水滴形式从云中落下的水。" },
        new() { Id = 51, VocabularyId = 5, LanguageId = 2, Word = "눈", Definition = "구름에서 내리는 얼어붙은 물의 결정" },
        new() { Id = 52, VocabularyId = 5, LanguageId = 3, Word = "Nieve", Definition = "Agua congelada que cae de las nubes en forma de copos." },
        new() { Id = 53, VocabularyId = 5, LanguageId = 4, Word = "雪", Definition = "以雪花形式从云中落下的冰冻水。" },
        new() { Id = 54, VocabularyId = 6, LanguageId = 2, Word = "진눈깨비", Definition = "비와 얼음 알갱이가 섞여 내리는 강수" },
        new() { Id = 55, VocabularyId = 6, LanguageId = 3, Word = "Aguanieve", Definition = "Precipitación que cae como una mezcla de lluvia y hielo." },
        new() { Id = 56, VocabularyId = 6, LanguageId = 4, Word = "雨夹雪", Definition = "雨和冰粒混合落下的降水。" },
        new() { Id = 57, VocabularyId = 7, LanguageId = 2, Word = "우박", Definition = "구름에서 떨어지는 얼음 덩어리" },
        new() { Id = 58, VocabularyId = 7, LanguageId = 3, Word = "Granizo", Definition = "Bolas o trozos de hielo que caen de las nubes." },
        new() { Id = 59, VocabularyId = 7, LanguageId = 4, Word = "冰雹", Definition = "从云中落下的冰块或冰粒。" },
        new() { Id = 60, VocabularyId = 8, LanguageId = 2, Word = "바람", Definition = "움직이는 공기" },
        new() { Id = 61, VocabularyId = 8, LanguageId = 3, Word = "Viento", Definition = "Aire en movimiento." },
        new() { Id = 62, VocabularyId = 8, LanguageId = 4, Word = "风", Definition = "流动的空气。" },
        new() { Id = 63, VocabularyId = 9, LanguageId = 2, Word = "풍속계", Definition = "바람의 속도를 측정하는 도구" },
        new() { Id = 64, VocabularyId = 9, LanguageId = 3, Word = "Anemómetro", Definition = "Instrumento que se usa para medir la velocidad del viento." },
        new() { Id = 65, VocabularyId = 9, LanguageId = 4, Word = "风速计", Definition = "用来测量风速的仪器。" }
    ];
}
