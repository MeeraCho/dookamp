using Dookamp.Application.Vocabulary;
using Microsoft.EntityFrameworkCore;

namespace Dookamp.Infrastructure;

public sealed class EfVocabularyQueries(LessonDbContext db) : IVocabularyQueries
{
    public async Task<IReadOnlyList<VocabularyDetails>> GetForLessonAsync(
        int lessonId,
        int languageId,
        CancellationToken cancellationToken = default)
    {
        var vocabulary = await db.LessonContentVocabulary
            .AsNoTracking()
            .Where(link => link.LessonContent.LessonId == lessonId)
            .Select(link => new
            {
                link.VocabularyId,
                Language = link.Vocabulary.Languages
                    .OrderByDescending(language => language.LanguageId == languageId)
                    .ThenByDescending(language => language.LanguageId == 1)
                    .Select(language => new { language.Word, language.Definition })
                    .FirstOrDefault()
            })
            .ToListAsync(cancellationToken);

        return vocabulary
            .Where(item => item.Language is not null)
            .Select(item => new VocabularyDetails(
                item.VocabularyId,
                item.Language!.Word,
                item.Language.Definition))
            .DistinctBy(item => item.Id)
            .ToList();
    }
}
