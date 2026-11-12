namespace DooKamp.Application.Features.Subjects.GetSubjects;
public sealed record GetSubjectsQuery(
    int? LocationId,
    int? GradeId);
