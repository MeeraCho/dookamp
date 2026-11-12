
using DooKamp.Application.DTOs.Subjects;
using DooKamp.Application.Interfaces.Subjects;
using DooKamp.Application.Exceptions;
using FluentValidation;

namespace DooKamp.Application.Features.Subjects.GetSubjects;

public sealed class GetSubjectsHandler
{
    private readonly IValidator<GetSubjectsQuery> _validator;
    private readonly ISubjectRepository _subjectRepository;

    public GetSubjectsHandler(
        ISubjectRepository subjectRepository,
        IValidator<GetSubjectsQuery> validator)
    {
        _subjectRepository = subjectRepository;
        _validator = validator;
    }

    public async Task<IReadOnlyList<SubjectListDto>> HandleAsync(
        GetSubjectsQuery query,
        CancellationToken cancellationToken = default)
    {
        // Validate the query
        var validationResult = await _validator.ValidateAsync(
            query,
            cancellationToken);

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

        // Retrieve subjects from the database
        var subjects = await _subjectRepository.GetSubjectsAsync(
            query.LocationId,
            query.GradeId,
            cancellationToken);

        // DTO Mapping
        return subjects
            .Select(subject => new SubjectListDto
            {
                Id = subject.Id,
                Name = subject.Name
            })
            .ToArray();
    }
}
