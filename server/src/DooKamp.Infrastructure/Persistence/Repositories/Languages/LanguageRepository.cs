using DooKamp.Application.Interfaces.Languages;
using DooKamp.Domain.Entities.Languages;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Repositories.Languages;

public sealed class LanguageRepository : ILanguageRepository
{
    private readonly DooKampDbContext _context;

    public LanguageRepository(DooKampDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Language>> GetLanguagesAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Languages
            .AsNoTracking()
            .OrderBy(language => language.Name)
            .ToListAsync(cancellationToken);
    }
}