
using DooKamp.Application.DTOs.Lessons;
using DooKamp.Application.DTOs.Quizzes;
using DooKamp.Application.Exceptions;
using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Domain.Entities.Languages;
using FluentValidation;

namespace DooKamp.Application.Features.Lessons.GetLesson;

public sealed class GetLessonHandler
{
    private readonly ILessonRepository _lessonRepository;
    private readonly IValidator<GetLessonQuery> _validator;

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

		// if validation failed, throw an ApplicationValidationException with the validation errors 
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

        // 2. Retrieve the lesson, if no lesson throw NotFoundException
        var lesson = await _lessonRepository.GetLessonByIdAsync(
            query.id,
            cancellationToken);

        if (lesson is null)
        {
            throw new NotFoundException(
                nameof(Domain.Entities.Lessons.Lesson),
                query.id);
        }

        // 4. Map content to LessonContentDto
        var contents = lesson.LessonContents
            .OrderBy(content => content.Order)
            .SelectMany(content => content.LessonContentLanguages
                .Select(contentLanguage => 
                    new LessonContentDto
                    {
                        Id = content.Id,
                        Order = content.Order,
                        LanguageCode = contentLanguage.Language.Code,
                        Text = contentLanguage.Text,
                        Vocabularies = content.LessonContentVocabularies
                            .SelectMany(contentVocab => contentVocab.Vocabulary.VocabularyLanguages
                                .Where(vocabularyLanguage => vocabularyLanguage.Language.Code == contentLanguage.Language.Code)
                                .Select(vocabularyLanguage => new VocabularyDto
                                    {
                                        Id = vocabularyLanguage.VocabularyId,
                                        Word = vocabularyLanguage.Word,
                                        Definition = vocabularyLanguage.Definition,
                                        LanguageCode = vocabularyLanguage.Language.Code
                                    })
                            )
                            .ToList(),

                        ConceptCheckQuestions = content.QuizQuestions
                            .OrderBy(quizQuestion => quizQuestion.Order)
                            .SelectMany(quizQuestion => quizQuestion.QuizQuestionLanguages
                                .Where(quizQuestionLanguage => quizQuestionLanguage.Language.Code == contentLanguage.Language.Code)
                                .Select(quizQuestionLanguage => new QuizQuestionDto
                                    {
                                        Id = quizQuestion.Id,
                                        QuestionText = quizQuestionLanguage.QuestionText,
                                        LanguageCode = quizQuestionLanguage.Language.Code,
                                        Order = quizQuestion.Order,
                                        QuizOptions = quizQuestion.QuizOptions
                                            .SelectMany(quizOption => quizOption.QuizOptionLanguages
                                                .Where(quizOptionLanguage => quizOptionLanguage.Language.Code == contentLanguage.Language.Code)
                                                .Select(quizOptionLanguage => new QuizOptionDto
                                                    {
                                                        Id = quizOption.Id,
                                                        Text = quizOptionLanguage.Text,
                                                        LanguageCode = quizOptionLanguage.Language.Code,
                                                        Order = quizOption.Order,
                                                    })
                                            )
                                            .ToList()
                                    })
                            )
                            .ToList()
                    })
            )
            .ToList();
        
        // 5. Map lesson-level quiz questions
        var quizQuestions = lesson.QuizQuestions
            .OrderBy(question => question.Order)
            .SelectMany(question => question.QuizQuestionLanguages
                .Select(questionLanguage => new QuizQuestionDto
                    {
                        Id = question.Id,
                        QuestionText = questionLanguage.QuestionText,
                        LanguageCode = questionLanguage.Language.Code,
                        Order = question.Order,
                        QuizOptions = question.QuizOptions
                            .SelectMany(option => option.QuizOptionLanguages
                                .Where(optionLanguage => optionLanguage.Language.Code == questionLanguage.Language.Code)
                                .Select(optionLanguage => new QuizOptionDto
                                    {
                                        Id = option.Id,
                                        Text = optionLanguage.Text,
                                        LanguageCode = optionLanguage.Language.Code,
                                        Order = option.Order,
                                    })
                            )
                            .ToList()
                    })
            )
            .ToList();


        // 3. Map lessonDetails to LessonDetailDto 
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
