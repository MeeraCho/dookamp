using DooKamp.Application.Interfaces.Locations;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public sealed class LocationRepository : ILocationRepository
{
    private readonly DooKampDbContext _context;

    public LocationRepository(DooKampDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Location>> GetLocationsAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Locations
            .AsNoTracking()
            .OrderBy(location => location.Name)
            .ToListAsync(cancellationToken);
    }
}