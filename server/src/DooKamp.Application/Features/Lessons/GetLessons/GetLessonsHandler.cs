
using DooKamp.Application.DTOs.Lessons;
using DooKamp.Application.Interfaces.Lessons;

namespace DooKamp.Application.Features.Lessons.GetLessons;

public sealed class GetLessonsHandler
{
    private readonly ILessonRepository _lessonRepository;

    public GetLessonsHandler(ILessonRepository lessonRepository)
    {
        _lessonRepository = lessonRepository;
    }

    public async Task<IReadOnlyList<LessonListDto>> HandleAsync(
        GetLessonsQuery query,
        CancellationToken cancellationToken = default)
    {
        var lessons = await _lessonRepository.GetLessonsAsync(
            query.LocationId,
            query.GradeId,
            cancellationToken);

        return lessons
            .Select(lesson => new LessonListDto
            {
                Id = lesson.Id,
                Title = lesson.Title,
                Description = lesson.Description,
                TopicNames = lesson.LessonTopics
                    .Select(lessonTopic => lessonTopic.Topic.Name)
                    .ToArray()
            })
            .ToArray();
    }
}
