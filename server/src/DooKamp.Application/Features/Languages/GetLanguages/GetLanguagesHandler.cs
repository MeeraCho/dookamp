using DooKamp.Application.DTOs.Languages;
using DooKamp.Application.Interfaces.Languages;

namespace DooKamp.Application.Features.Languages.GetLanguages;

public sealed class GetLanguagesHandler
{
    private readonly ILanguageRepository _languageRepository;

    public GetLanguagesHandler(ILanguageRepository languageRepository)
    {
        _languageRepository = languageRepository;
    }

    public async Task<IReadOnlyList<LanguageListDto>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var languages = await _languageRepository.GetLanguagesAsync(
            cancellationToken);

        return languages.Select(language => new LanguageListDto
        {
            Id = language.Id,
            Code = language.Code,
            Name = language.Name
        }).ToList();
    }
}