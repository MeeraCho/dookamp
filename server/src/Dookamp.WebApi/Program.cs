using Dookamp.Application.Lessons;
using Dookamp.Application.Locations;
using Dookamp.Application.Quiz;
using Dookamp.Application.Vocabulary;
using Dookamp.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LessonDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Dookamp")));
builder.Services.AddScoped<ILessonQueries, EfLessonQueries>();
builder.Services.AddScoped<GetLessonByIdHandler>();
builder.Services.AddScoped<ILocationQueries, EfLocationQueries>();
builder.Services.AddScoped<GetLocationsHandler>();
builder.Services.AddScoped<IVocabularyQueries, EfVocabularyQueries>();
builder.Services.AddScoped<GetLessonVocabularyHandler>();
builder.Services.AddScoped<IQuizQueries, EfQuizQueries>();
builder.Services.AddScoped<GetLessonQuizHandler>();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/health", () => Results.Ok(new { status = "ok" }));

app.MapGet("/api/locations", async (
    GetLocationsHandler handler,
    CancellationToken cancellationToken) =>
    Results.Ok(await handler.HandleAsync(cancellationToken)));

app.MapGet("/api/lessons/{lessonId:int}", async (
    int lessonId,
    int? languageId,
    GetLessonByIdHandler handler,
    CancellationToken cancellationToken) =>
{
    var lesson = await handler.HandleAsync(
        lessonId,
        languageId ?? 1,
        cancellationToken);

    return lesson is null
        ? Results.NotFound()
        : Results.Ok(lesson);
});

app.MapGet("/api/lessons/{lessonId:int}/vocabulary", async (
    int lessonId,
    int? languageId,
    GetLessonVocabularyHandler handler,
    CancellationToken cancellationToken) =>
    Results.Ok(await handler.HandleAsync(
        lessonId,
        languageId ?? 1,
        cancellationToken)));

app.MapGet("/api/lessons/{lessonId:int}/quiz", async (
    int lessonId,
    int? languageId,
    GetLessonQuizHandler handler,
    CancellationToken cancellationToken) =>
{
    var quiz = await handler.HandleAsync(
        lessonId,
        languageId ?? 1,
        cancellationToken);

    return quiz is null
        ? Results.NotFound()
        : Results.Ok(quiz);
});

app.Run();

public partial class Program;
