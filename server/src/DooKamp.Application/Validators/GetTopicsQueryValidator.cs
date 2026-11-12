using DooKamp.Application.Features.Topics.GetTopics;
using FluentValidation;

namespace DooKamp.Application.Validators;

public sealed class GetTopicsQueryValidator
    : AbstractValidator<GetTopicsQuery>
{
    public GetTopicsQueryValidator()
    {
        RuleFor(x => x.SubjectId)
            .GreaterThan(0)
            .When(x => x.SubjectId.HasValue);

        RuleFor(x => x.LocationId)
            .GreaterThan(0)
            .When(x => x.LocationId.HasValue);

        RuleFor(x => x.GradeId)
            .GreaterThan(0)
            .When(x => x.GradeId.HasValue);

        RuleFor(x => x.ParentTopicId)
            .GreaterThan(0)
            .When(x => x.ParentTopicId.HasValue);
    }
}