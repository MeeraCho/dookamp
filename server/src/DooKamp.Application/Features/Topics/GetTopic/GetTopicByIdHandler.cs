using DooKamp.Application.DTOs.Topics;
using DooKamp.Application.Interfaces.Topics;
using DooKamp.Application.Exceptions;
using FluentValidation;

namespace DooKamp.Application.Features.Topics.GetTopicById;

public sealed class GetTopicByIdHandler(
    ITopicRepository topicRepository,
    IValidator<GetTopicByIdQuery> validator)
{
    public async Task<TopicDetailDto?> HandleAsync(
        GetTopicByIdQuery query,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await validator.ValidateAsync(query);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(error => error.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(error => error.ErrorMessage).ToArray());

            throw new ApplicationValidationException(errors);
        }

        var topic = await topicRepository.GetTopicByIdAsync(
            query.Id,
            cancellationToken);

        if (topic is null)
        {
            return null;
        }

        return new TopicDetailDto
        {
            Id = topic.Id,
            Name = topic.Name,
            Description = topic.Description,
            ParentTopicId = topic.ParentTopicId,
            SubjectId = topic.SubjectId,

            ChildTopics = topic.ChildTopics
                .Select(child => new TopicListDto
                {
                    Id = child.Id,
                    Name = child.Name,
                    Description = child.Description,
                    ParentTopicId = child.ParentTopicId,
                    SubjectId = child.SubjectId
                })
                .ToList(),

            Lessons = topic.TopicLessons
                .Select(topicLesson => new TopicLessonDto
                {
                    Id = topicLesson.Lesson.Id,
                    Title = topicLesson.Lesson.Title,
                    Description = topicLesson.Lesson.Description
                })
                .ToList()
        };
    }
}