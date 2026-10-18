
using DooKamp.Application.Features.Lessons.GetLessons;
using FluentValidation;

namespace DooKamp.Application.Validators;

public sealed class GetLessonsQueryValidator: AbstractValidator<GetLessonsQuery>
{
    public GetLessonsQueryValidator()
    {
        RuleFor(x => x.LocationId)
            .GreaterThan(0)
            .When(x => x.LocationId.HasValue);

        RuleFor(x => x.GradeId)
            .GreaterThan(0)
            .When(x => x.GradeId.HasValue);
    }
}