using FluentValidation;

public sealed class GetLessonQueryValidator : AbstractValidator<GetLessonQuery>
{
    public GetLessonQueryValidator()
    {
        RuleFor(query => query.id)
            .GreaterThan(0)
            .WithMessage("Lesson Id must be greater than 0.");
    }
}
