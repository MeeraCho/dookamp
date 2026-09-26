using System.Net;
using System.Net.Http.Json;
using Dookamp.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;

namespace Dookamp.WebApi.Tests;

public sealed class ApiTests : IClassFixture<TestApiFactory>
{
    private readonly HttpClient client;

    public ApiTests(TestApiFactory factory) => client = factory.CreateClient();

    [Fact]
    public async Task LocationsEndpointReturnsSeededLocations()
    {
        var response = await client.GetAsync("/api/locations");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("Alberta", body);
        Assert.Contains("Ontario", body);
    }

    [Fact]
    public async Task QuizEndpointReturnsKoreanQuestionAndOptions()
    {
        var response = await client.GetAsync("/api/lessons/1/quiz?languageId=2");

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        var body = await response.Content.ReadAsStringAsync();
        Assert.Contains("날씨란 무엇인가?", body);
        Assert.Contains("공기와 하늘의 상태", body);
    }
}

public sealed class TestApiFactory : WebApplicationFactory<Program>
{
    private readonly SqliteConnection connection = new("Data Source=:memory:");

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        connection.Open();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<LessonDbContext>>();
            services.AddSingleton(connection);
            services.AddDbContext<LessonDbContext>(options => options.UseSqlite(connection));

            using var serviceProvider = services.BuildServiceProvider();
            using var scope = serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<LessonDbContext>();
            db.Database.EnsureCreated();
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            connection.Dispose();
        }

        base.Dispose(disposing);
    }
}
