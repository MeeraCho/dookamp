using Dookamp.Application.Lessons;
using Dookamp.Application.Locations;
using Xunit;

namespace Dookamp.Application.Tests;

public sealed class LessonQueriesTests
{
    [Fact]
    public async Task GetLessonByIdHandler_DelegatesToQueryPort()
    {
        var expected = new LessonDetails(
            1,
            9,
            "Weather",
            "Weather description",
            [new LessonContentDetails(1, 1, "Weather content")],
            []);
        var queries = new FakeLessonQueries(expected);
        var handler = new GetLessonByIdHandler(queries);

        var result = await handler.HandleAsync(1, 2);

        Assert.Equal(expected, result);
        Assert.Equal((1, 2), queries.LastRequest);
    }

    [Fact]
    public async Task GetLessonByIdHandler_ReturnsNullWhenLessonDoesNotExist()
    {
        var queries = new FakeLessonQueries(null);
        var handler = new GetLessonByIdHandler(queries);

        var result = await handler.HandleAsync(999, 1);

        Assert.Null(result);
    }

    private sealed class FakeLessonQueries(LessonDetails? result) : ILessonQueries
    {
        public (int LessonId, int LanguageId)? LastRequest { get; private set; }

        public Task<LessonDetails?> GetByIdAsync(
            int lessonId,
            int languageId,
            CancellationToken cancellationToken = default)
        {
            LastRequest = (lessonId, languageId);
            return Task.FromResult(result);
        }
    }
}

public sealed class LocationQueriesTests
{
    [Fact]
    public async Task GetLocationsHandler_DelegatesToQueryPort()
    {
        IReadOnlyList<LocationDetails> expected =
        [
            new(1, "Alberta", "AB", "Canada"),
            new(2, "Ontario", "ON", "Canada")
        ];
        var queries = new FakeLocationQueries(expected);
        var handler = new GetLocationsHandler(queries);

        var result = await handler.HandleAsync();

        Assert.Equal(expected, result);
        Assert.True(queries.WasCalled);
    }

    private sealed class FakeLocationQueries(IReadOnlyList<LocationDetails> result) : ILocationQueries
    {
        public bool WasCalled { get; private set; }

        public Task<IReadOnlyList<LocationDetails>> GetAllAsync(
            CancellationToken cancellationToken = default)
        {
            WasCalled = true;
            return Task.FromResult(result);
        }
    }
}
