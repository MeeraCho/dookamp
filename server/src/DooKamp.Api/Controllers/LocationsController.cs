
using DooKamp.Application.Features.Locations.GetLocations;
using Microsoft.AspNetCore.Mvc;

namespace DooKamp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class LocationsController : ControllerBase
{
    private readonly GetLocationsHandler _getLocationsHandler;

    public LocationsController(GetLocationsHandler getLocationsHandler)
    {
        _getLocationsHandler = getLocationsHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetLocations(
        CancellationToken cancellationToken)
    {
        var locations = await _getLocationsHandler.HandleAsync(
            cancellationToken);

        return Ok(locations);
    }
}