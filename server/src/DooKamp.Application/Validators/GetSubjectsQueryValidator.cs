
using DooKamp.Application.Features.Subjects.GetSubjects;
using FluentValidation;

namespace DooKamp.Application.Validators;

public sealed class GetSubjectsQueryValidator
    : AbstractValidator<GetSubjectsQuery>
{
    public GetSubjectsQueryValidator()
    {
        RuleFor(x => x.LocationId)
            .GreaterThan(0)
            .When(x => x.LocationId.HasValue);

        RuleFor(x => x.GradeId)
            .GreaterThan(0)
            .When(x => x.GradeId.HasValue);
    }
}
