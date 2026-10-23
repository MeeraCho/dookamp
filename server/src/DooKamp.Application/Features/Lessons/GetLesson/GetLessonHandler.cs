
using DooKamp.Application.DTOs.Lessons;
using DooKamp.Application.DTOs.Quizzes;
using DooKamp.Application.Exceptions;
using DooKamp.Application.Interfaces.Lessons;
using FluentValidation;

namespace DooKamp.Application.Features.Lessons.GetLesson;

public sealed class GetLessonHandler
{
    private readonly IValidator<GetLessonQuery> _validator;
    private readonly ILessonRepository _lessonRepository;

    public GetLessonHandler(
        ILessonRepository lessonRepository,
        IValidator<GetLessonQuery> validator)
    {
        _lessonRepository = lessonRepository;
        _validator = validator;
    }

    public async Task<LessonDetailDto> HandleAsync(
        GetLessonQuery query,
        CancellationToken cancellationToken = default)
    {
        // 1. Validate the query
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
                    StringComparer.Ordinal);

            throw new ApplicationValidationException(errors);
        }

        // 2. Retrieve the lesson
        var lesson = await _lessonRepository.GetLessonByIdAsync(
            query.id,
            cancellationToken);

        if (lesson is null)
        {
            throw new NotFoundException(
                nameof(Domain.Entities.Lessons.Lesson),
                query.id);
        }

        // 3. Map Lesson to LessonDetailDto
        var contents = lesson.LessonContents
            .OrderBy(content => content.Order)
            .SelectMany(content =>
                content.Languages.Select(contentLanguage =>
                    new LessonContentDto
                    {
                        Id = content.Id,
                        Order = content.Order,
                        LanguageCode = contentLanguage.Language.Code,
                        Text = contentLanguage.Text,

                        // Vocabulary in the same language
                        Vocabularies = content.Vocabularies
                            .SelectMany(contentVocabulary =>
                                contentVocabulary.Vocabulary.Languages
                                    .Where(vocabularyLanguage =>
                                        vocabularyLanguage.Language.Code ==
                                        contentLanguage.Language.Code)
                                    .Select(vocabularyLanguage =>
                                        new VocabularyDto
                                        {
                                            Id = contentVocabulary.Vocabulary.Id,
                                            Word = vocabularyLanguage.Word,
                                            Definition = vocabularyLanguage.Definition,
                                            LanguageCode = vocabularyLanguage.Language.Code
                                        }))
                            .ToArray(),

                        // Concept-check questions in the same language
                        ConceptCheckQuestions = content.QuizQuestions
                            .OrderBy(question => question.Order)
                            .SelectMany(question =>
                                question.Languages
                                    .Where(questionLanguage =>
                                        questionLanguage.Language.Code ==
                                        contentLanguage.Language.Code)
                                    .Select(questionLanguage =>
                                        new QuizQuestionDto
                                        {
                                            Id = question.Id,
                                            QuestionText = questionLanguage.QuestionText,
                                            LanguageCode = questionLanguage.Language.Code,
                                            Order = question.Order ?? 0,

                                            Options = question.Options
                                                .SelectMany(option =>
                                                    option.Languages
                                                        .Where(optionLanguage =>
                                                            optionLanguage.Language.Code ==
                                                            questionLanguage.Language.Code)
                                                        .Select(optionLanguage =>
                                                            new QuizOptionDto
                                                            {
                                                                Id = option.Id,
                                                                Text = optionLanguage.Text,
                                                                LanguageCode = optionLanguage.Language.Code,
                                                                Order = option.Order
                                                            }))
                                                .OrderBy(option => option.Order)
                                                .ToArray()
                                        }))
                            .ToArray()
                    }))
            .ToArray();

        // 4. Map lesson-level quiz questions
        var quizQuestions = lesson.QuizQuestions
            .OrderBy(question => question.Order)
            .SelectMany(question =>
                question.Languages.Select(questionLanguage =>
                    new QuizQuestionDto
                    {
                        Id = question.Id,
                        QuestionText = questionLanguage.QuestionText,
                        LanguageCode = questionLanguage.Language.Code,
                        Order = question.Order ?? 0,

                        Options = question.Options
                            .SelectMany(option =>
                                option.Languages
                                    .Where(optionLanguage =>
                                        optionLanguage.Language.Code ==
                                        questionLanguage.Language.Code)
                                    .Select(optionLanguage =>
                                        new QuizOptionDto
                                        {
                                            Id = option.Id,
                                            Text = optionLanguage.Text,
                                            LanguageCode = optionLanguage.Language.Code,
                                            Order = option.Order
                                        }))
                            .OrderBy(option => option.Order)
                            .ToArray()
                    }))
            .ToArray();

        // 5. Return the lesson details
        return new LessonDetailDto
        {
            Id = lesson.Id,
            Title = lesson.Title,
            Description = lesson.Description,
            Contents = contents,
            QuizQuestions = quizQuestions
        };
    }
}
