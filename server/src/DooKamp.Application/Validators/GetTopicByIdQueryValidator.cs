using DooKamp.Application.Features.Topics.GetTopicById;
using FluentValidation;

namespace DooKamp.Application.Validators;

public sealed class GetTopicByIdQueryValidator
    : AbstractValidator<GetTopicByIdQuery>
{
    public GetTopicByIdQueryValidator()
    {
        RuleFor(query => query.Id)
            .GreaterThan(0);
    }
}