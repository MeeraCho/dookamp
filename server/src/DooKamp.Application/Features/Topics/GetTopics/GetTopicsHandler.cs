using DooKamp.Application.DTOs.Topics;
using DooKamp.Application.Interfaces.Topics;
using DooKamp.Application.Exceptions;
using FluentValidation;

namespace DooKamp.Application.Features.Topics.GetTopics;

public sealed class GetTopicsHandler
{
    private readonly ITopicRepository _topicRepository;
    private readonly IValidator<GetTopicsQuery> _validator;

    public GetTopicsHandler(
        ITopicRepository topicRepository,
        IValidator<GetTopicsQuery> validator)
    {
        _topicRepository = topicRepository;
        _validator = validator;
    }

    public async Task<IReadOnlyList<TopicListDto>> HandleAsync(
        GetTopicsQuery query,
        CancellationToken cancellationToken = default)
    {
        var validationResult = await _validator.ValidateAsync(
            query,
            cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(x => x.ErrorMessage).ToArray());

            throw new ApplicationValidationException(errors);
        }

        var topics = await _topicRepository.GetTopicsAsync(
            query.SubjectId,
            query.LocationId,
            query.GradeId,
            query.ParentTopicId,
            cancellationToken);

        return topics.Select(topic => new TopicListDto
        {
            Id = topic.Id,
            Name = topic.Name,
            Description = topic.Description,
            ParentTopicId = topic.ParentTopicId,
            SubjectId = topic.SubjectId
        }).ToList();
    }
}