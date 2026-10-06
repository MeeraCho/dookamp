using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LocationSeed
{
    public static async Task SeedAsync(
        DooKampDbContext context)
    {
        if (await context.Locations.AnyAsync())
            return;

        var locations = new[]
        {
            new Location("Alberta", "AB", "Canada"),
            new Location("British Columbia", "BC", "Canada"),
            new Location("Manitoba", "MB", "Canada"),
            new Location("New Brunswick", "NB", "Canada"),
            new Location("Newfoundland and Labrador", "NL", "Canada"),
            new Location("Nova Scotia", "NS", "Canada"),
            new Location("Ontario", "ON", "Canada"),
            new Location("Prince Edward Island", "PE", "Canada"),
            new Location("Quebec", "QC", "Canada"),
            new Location("Saskatchewan", "SK", "Canada"),
            new Location("Northwest Territories", "NT", "Canada"),
            new Location("Nunavut", "NU", "Canada"),
            new Location("Yukon", "YT", "Canada"),

            new Location("Alabama", "AL", "United States"),
            new Location("Alaska", "AK", "United States"),
            new Location("Arizona", "AZ", "United States"),
            new Location("Arkansas", "AR", "United States"),
            new Location("California", "CA", "United States"),
            new Location("Colorado", "CO", "United States"),
            new Location("Connecticut", "CT", "United States"),
            new Location("Delaware", "DE", "United States"),
            new Location("Florida", "FL", "United States"),
            new Location("Georgia", "GA", "United States"),
            new Location("Hawaii", "HI", "United States"),
            new Location("Idaho", "ID", "United States"),
            new Location("Illinois", "IL", "United States"),
            new Location("Indiana", "IN", "United States"),
            new Location("Iowa", "IA", "United States"),
            new Location("Kansas", "KS", "United States"),
            new Location("Kentucky", "KY", "United States"),
            new Location("Louisiana", "LA", "United States"),
            new Location("Maine", "ME", "United States"),
            new Location("Maryland", "MD", "United States"),
            new Location("Massachusetts", "MA", "United States"),
            new Location("Michigan", "MI", "United States"),
            new Location("Minnesota", "MN", "United States"),
            new Location("Mississippi", "MS", "United States"),
            new Location("Missouri", "MO", "United States"),
            new Location("Montana", "MT", "United States"),
            new Location("Nebraska", "NE", "United States"),
            new Location("Nevada", "NV", "United States"),
            new Location("New Hampshire", "NH", "United States"),
            new Location("New Jersey", "NJ", "United States"),
            new Location("New Mexico", "NM", "United States"),
            new Location("New York", "NY", "United States"),
            new Location("North Carolina", "NC", "United States"),
            new Location("North Dakota", "ND", "United States"),
            new Location("Ohio", "OH", "United States"),
            new Location("Oklahoma", "OK", "United States"),
            new Location("Oregon", "OR", "United States"),
            new Location("Pennsylvania", "PA", "United States"),
            new Location("Rhode Island", "RI", "United States"),
            new Location("South Carolina", "SC", "United States"),
            new Location("South Dakota", "SD", "United States"),
            new Location("Tennessee", "TN", "United States"),
            new Location("Texas", "TX", "United States"),
            new Location("Utah", "UT", "United States"),
            new Location("Vermont", "VT", "United States"),
            new Location("Virginia", "VA", "United States"),
            new Location("Washington", "WA", "United States"),
            new Location("West Virginia", "WV", "United States"),
            new Location("Wisconsin", "WI", "United States"),
            new Location("Wyoming", "WY", "United States"),
            new Location("District of Columbia", "DC", "United States")
        };

        await context.Locations.AddRangeAsync(locations);
        await context.SaveChangesAsync();
    }
}