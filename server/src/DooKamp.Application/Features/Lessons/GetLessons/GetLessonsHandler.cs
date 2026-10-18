
using DooKamp.Application.DTOs.Lessons;
using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Application.Exceptions;
using FluentValidation;

namespace DooKamp.Application.Features.Lessons.GetLessons;

public sealed class GetLessonsHandler
{
    private readonly IValidator<GetLessonsQuery> _validator;
    private readonly ILessonRepository _lessonRepository;
    

    public GetLessonsHandler(ILessonRepository lessonRepository, IValidator<GetLessonsQuery> validator)
    {
        _lessonRepository = lessonRepository;
        _validator = validator;
    }

    public async Task<IReadOnlyList<LessonListDto>> HandleAsync(
        GetLessonsQuery query,
        CancellationToken cancellationToken = default)
    {
        // Validate the query
        var validationResult = await _validator.ValidateAsync(query, cancellationToken);
        if (!validationResult.IsValid)
        {  
            var errors = validationResult.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group
                        .Select(error => error.ErrorMessage)
                        .ToArray(),
                    StringComparer.Ordinal
                );
            throw new ApplicationValidationException(errors);
            
        }

         // Retrieve lessons from the database
        var lessons = await _lessonRepository.GetLessonsAsync(
            query.LocationId,
            query.GradeId,
            cancellationToken);

        // DTO Mapping
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
