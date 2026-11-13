using DooKamp.Domain.Entities.Languages;

namespace DooKamp.Application.Interfaces.Languages;

public interface ILanguageRepository
{
    Task<IReadOnlyList<Language>> GetLanguagesAsync(
        CancellationToken cancellationToken = default);
}