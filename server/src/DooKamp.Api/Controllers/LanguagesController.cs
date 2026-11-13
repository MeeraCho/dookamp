using DooKamp.Application.Features.Languages.GetLanguages;
using DooKamp.Application.DTOs.Languages;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/languages")]
public sealed class LanguagesController : ControllerBase
{
    private readonly GetLanguagesHandler _getLanguagesHandler;

    public LanguagesController(GetLanguagesHandler getLanguagesHandler)
    {
        _getLanguagesHandler = getLanguagesHandler;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<LanguageListDto>>> GetLanguages(
        CancellationToken cancellationToken)
    {
        var languages = await _getLanguagesHandler.HandleAsync(
            cancellationToken);

        return Ok(languages);
    }
}