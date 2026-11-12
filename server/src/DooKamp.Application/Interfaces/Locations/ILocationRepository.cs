using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Application.Interfaces.Locations;

public interface ILocationRepository
{
    Task<IReadOnlyList<Location>> GetLocationsAsync(
        CancellationToken cancellationToken = default);
}