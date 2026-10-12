namespace DooKamp.Application.Features.Lessons.GetLessons;

public sealed record GetLessonsQuery(
    int LocationId,
    int GradeId);