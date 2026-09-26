namespace Dookamp.Application.Locations;

public sealed record LocationDetails(
    int Id,
    string Name,
    string Code,
    string Country);

public interface ILocationQueries
{
    Task<IReadOnlyList<LocationDetails>> GetAllAsync(
        CancellationToken cancellationToken = default);
}

public sealed class GetLocationsHandler(ILocationQueries locationQueries)
{
    public Task<IReadOnlyList<LocationDetails>> HandleAsync(
        CancellationToken cancellationToken = default) =>
        locationQueries.GetAllAsync(cancellationToken);
}
