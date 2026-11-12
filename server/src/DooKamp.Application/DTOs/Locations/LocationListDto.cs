namespace DooKamp.Application.DTOs.Locations;

public class LocationListDto
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
}