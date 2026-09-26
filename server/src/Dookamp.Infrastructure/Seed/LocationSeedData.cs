namespace Dookamp.Infrastructure.Seed;

public sealed class LocationSeed
{
    public int Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;
}

public static class LocationSeedData
{
    public static IReadOnlyList<LocationSeed> All { get; } =
    [
        new() { Id = 1, Name = "Alberta", Code = "AB", Country = "Canada" },
        new() { Id = 2, Name = "British Columbia", Code = "BC", Country = "Canada" },
        new() { Id = 3, Name = "Manitoba", Code = "MB", Country = "Canada" },
        new() { Id = 4, Name = "New Brunswick", Code = "NB", Country = "Canada" },
        new() { Id = 5, Name = "Newfoundland and Labrador", Code = "NL", Country = "Canada" },
        new() { Id = 6, Name = "Nova Scotia", Code = "NS", Country = "Canada" },
        new() { Id = 7, Name = "Ontario", Code = "ON", Country = "Canada" },
        new() { Id = 8, Name = "Prince Edward Island", Code = "PE", Country = "Canada" },
        new() { Id = 9, Name = "Quebec", Code = "QC", Country = "Canada" },
        new() { Id = 10, Name = "Saskatchewan", Code = "SK", Country = "Canada" },
        new() { Id = 11, Name = "Northwest Territories", Code = "NT", Country = "Canada" },
        new() { Id = 12, Name = "Nunavut", Code = "NU", Country = "Canada" },
        new() { Id = 13, Name = "Yukon", Code = "YT", Country = "Canada" },
        new() { Id = 14, Name = "Alabama", Code = "AL", Country = "United States" },
        new() { Id = 15, Name = "Alaska", Code = "AK", Country = "United States" },
        new() { Id = 16, Name = "Arizona", Code = "AZ", Country = "United States" },
        new() { Id = 17, Name = "Arkansas", Code = "AR", Country = "United States" },
        new() { Id = 18, Name = "California", Code = "CA", Country = "United States" },
        new() { Id = 19, Name = "Colorado", Code = "CO", Country = "United States" },
        new() { Id = 20, Name = "Connecticut", Code = "CT", Country = "United States" },
        new() { Id = 21, Name = "Delaware", Code = "DE", Country = "United States" },
        new() { Id = 22, Name = "Florida", Code = "FL", Country = "United States" },
        new() { Id = 23, Name = "Georgia", Code = "GA", Country = "United States" },
        new() { Id = 24, Name = "Hawaii", Code = "HI", Country = "United States" },
        new() { Id = 25, Name = "Idaho", Code = "ID", Country = "United States" },
        new() { Id = 26, Name = "Illinois", Code = "IL", Country = "United States" },
        new() { Id = 27, Name = "Indiana", Code = "IN", Country = "United States" },
        new() { Id = 28, Name = "Iowa", Code = "IA", Country = "United States" },
        new() { Id = 29, Name = "Kansas", Code = "KS", Country = "United States" },
        new() { Id = 30, Name = "Kentucky", Code = "KY", Country = "United States" },
        new() { Id = 31, Name = "Louisiana", Code = "LA", Country = "United States" },
        new() { Id = 32, Name = "Maine", Code = "ME", Country = "United States" },
        new() { Id = 33, Name = "Maryland", Code = "MD", Country = "United States" },
        new() { Id = 34, Name = "Massachusetts", Code = "MA", Country = "United States" },
        new() { Id = 35, Name = "Michigan", Code = "MI", Country = "United States" },
        new() { Id = 36, Name = "Minnesota", Code = "MN", Country = "United States" },
        new() { Id = 37, Name = "Mississippi", Code = "MS", Country = "United States" },
        new() { Id = 38, Name = "Missouri", Code = "MO", Country = "United States" },
        new() { Id = 39, Name = "Montana", Code = "MT", Country = "United States" },
        new() { Id = 40, Name = "Nebraska", Code = "NE", Country = "United States" },
        new() { Id = 41, Name = "Nevada", Code = "NV", Country = "United States" },
        new() { Id = 42, Name = "New Hampshire", Code = "NH", Country = "United States" },
        new() { Id = 43, Name = "New Jersey", Code = "NJ", Country = "United States" },
        new() { Id = 44, Name = "New Mexico", Code = "NM", Country = "United States" },
        new() { Id = 45, Name = "New York", Code = "NY", Country = "United States" },
        new() { Id = 46, Name = "North Carolina", Code = "NC", Country = "United States" },
        new() { Id = 47, Name = "North Dakota", Code = "ND", Country = "United States" },
        new() { Id = 48, Name = "Ohio", Code = "OH", Country = "United States" },
        new() { Id = 49, Name = "Oklahoma", Code = "OK", Country = "United States" },
        new() { Id = 50, Name = "Oregon", Code = "OR", Country = "United States" },
        new() { Id = 51, Name = "Pennsylvania", Code = "PA", Country = "United States" },
        new() { Id = 52, Name = "Rhode Island", Code = "RI", Country = "United States" },
        new() { Id = 53, Name = "South Carolina", Code = "SC", Country = "United States" },
        new() { Id = 54, Name = "South Dakota", Code = "SD", Country = "United States" },
        new() { Id = 55, Name = "Tennessee", Code = "TN", Country = "United States" },
        new() { Id = 56, Name = "Texas", Code = "TX", Country = "United States" },
        new() { Id = 57, Name = "Utah", Code = "UT", Country = "United States" },
        new() { Id = 58, Name = "Vermont", Code = "VT", Country = "United States" },
        new() { Id = 59, Name = "Virginia", Code = "VA", Country = "United States" },
        new() { Id = 60, Name = "Washington", Code = "WA", Country = "United States" },
        new() { Id = 61, Name = "West Virginia", Code = "WV", Country = "United States" },
        new() { Id = 62, Name = "Wisconsin", Code = "WI", Country = "United States" },
        new() { Id = 63, Name = "Wyoming", Code = "WY", Country = "United States" },
        new() { Id = 64, Name = "District of Columbia", Code = "DC", Country = "United States" }
    ];
}
