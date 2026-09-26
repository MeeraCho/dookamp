using Dookamp.Application.Locations;
using Microsoft.EntityFrameworkCore;

namespace Dookamp.Infrastructure;

public sealed class EfLocationQueries(LessonDbContext db) : ILocationQueries
{
    public async Task<IReadOnlyList<LocationDetails>> GetAllAsync(
        CancellationToken cancellationToken = default) =>
        await db.Locations
            .AsNoTracking()
            .OrderBy(x => x.Country)
            .ThenBy(x => x.Name)
            .Select(x => new LocationDetails(x.Id, x.Name, x.Code, x.Country))
            .ToListAsync(cancellationToken);
}
