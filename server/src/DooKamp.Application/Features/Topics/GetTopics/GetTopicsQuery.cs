namespace DooKamp.Application.Features.Topics.GetTopics;

public sealed record GetTopicsQuery(
    int? SubjectId,
    int? LocationId,
    int? GradeId,
    int? ParentTopicId);