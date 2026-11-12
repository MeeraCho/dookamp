using DooKamp.Application.DTOs.Locations;
using DooKamp.Application.Interfaces.Locations;

namespace DooKamp.Application.Features.Locations.GetLocations;

public sealed class GetLocationsHandler
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationsHandler(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }

    public async Task<IReadOnlyList<LocationListDto>> HandleAsync(
        CancellationToken cancellationToken = default)
    {
        var locations = await _locationRepository.GetLocationsAsync(
            cancellationToken);

        return locations.Select(location => new LocationListDto
        {
            Id = location.Id,
            Name = location.Name,
            Code = location.Code,
            Country = location.Country
        }).ToList();
    }
}