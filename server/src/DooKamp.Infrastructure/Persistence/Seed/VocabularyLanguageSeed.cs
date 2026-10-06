using DooKamp.Domain.Entities.Vocabs;
using DooKamp.Domain.Entities.Languages;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class VocabularyLanguageSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.VocabularyLanguages.AnyAsync())
            return;

        var englishId = await context.Languages
            .Where(x => x.Code == "en")
            .Select(x => x.Id)
            .SingleAsync();

        var koreanId = await context.Languages
            .Where(x => x.Code == "ko")
            .Select(x => x.Id)
            .SingleAsync();

        var vocabularies = await context.Vocabularies
            .ToDictionaryAsync(x => x.Code, x => x.Id);

        var vocabularyLanguages = new[]
        {
            new VocabularyLanguage(
                vocabularies["cell"],
                englishId,
                "cell",
                "The basic unit that makes up all living things."),

            new VocabularyLanguage(
                vocabularies["cell"],
                koreanId,
                "세포",
                "모든 생물을 이루는 기본 단위."),

            new VocabularyLanguage(
                vocabularies["nucleus"],
                englishId,
                "nucleus",
                "The part of a cell that controls the cell's activities."),

            new VocabularyLanguage(
                vocabularies["nucleus"],
                koreanId,
                "핵",
                "세포의 활동을 조절하는 부분."),

            new VocabularyLanguage(
                vocabularies["membrane"],
                englishId,
                "cell membrane",
                "The thin layer that controls what enters and leaves a cell."),

            new VocabularyLanguage(
                vocabularies["membrane"],
                koreanId,
                "세포막",
                "세포 안팎으로 물질이 들어오고 나가는 것을 조절하는 얇은 막."),

            new VocabularyLanguage(
                vocabularies["cytoplasm"],
                englishId,
                "cytoplasm",
                "The jelly-like material inside a cell."),

            new VocabularyLanguage(
                vocabularies["cytoplasm"],
                koreanId,
                "세포질",
                "세포 안에 있는 젤리 같은 물질."),

            new VocabularyLanguage(
                vocabularies["organ"],
                englishId,
                "organ",
                "A body part that performs a specific function."),

            new VocabularyLanguage(
                vocabularies["organ"],
                koreanId,
                "기관",
                "특정한 기능을 수행하는 몸의 한 부분."),

            new VocabularyLanguage(
                vocabularies["tissue"],
                englishId,
                "tissue",
                "A group of similar cells that work together."),

            new VocabularyLanguage(
                vocabularies["tissue"],
                koreanId,
                "조직",
                "비슷한 세포들이 모여 함께 기능하는 것."),

            new VocabularyLanguage(
                vocabularies["organ_system"],
                englishId,
                "organ system",
                "A group of organs that work together."),

            new VocabularyLanguage(
                vocabularies["organ_system"],
                koreanId,
                "기관계",
                "여러 기관이 함께 작용하는 체계."),

            new VocabularyLanguage(
                vocabularies["digestive_system"],
                englishId,
                "digestive system",
                "The organ system that breaks down food and absorbs nutrients."),

            new VocabularyLanguage(
                vocabularies["digestive_system"],
                koreanId,
                "소화계",
                "음식을 분해하고 영양소를 흡수하는 기관계."),

            new VocabularyLanguage(
                vocabularies["respiratory_system"],
                englishId,
                "respiratory system",
                "The organ system that helps the body take in oxygen and remove carbon dioxide."),

            new VocabularyLanguage(
                vocabularies["respiratory_system"],
                koreanId,
                "호흡계",
                "산소를 받아들이고 이산화탄소를 내보내는 기관계."),

            new VocabularyLanguage(
                vocabularies["circulatory_system"],
                englishId,
                "circulatory system",
                "The organ system that moves blood throughout the body."),

            new VocabularyLanguage(
                vocabularies["circulatory_system"],
                koreanId,
                "순환계",
                "혈액을 온몸으로 순환시키는 기관계.")
        };

        await context.VocabularyLanguages.AddRangeAsync(vocabularyLanguages);
        await context.SaveChangesAsync();
    }
}