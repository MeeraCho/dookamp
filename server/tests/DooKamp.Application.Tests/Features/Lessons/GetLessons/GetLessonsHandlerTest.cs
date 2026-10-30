using DooKamp.Application.Features.Lessons.GetLessons;
using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Domain.Entities.Lessons;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace DooKamp.Application.Tests.Features.Lessons.GetLessons;

public class GetLessonsHandlerTests
{
    [Fact]
    public async Task HandleAsync_ValidQuery_ReturnsMappedLessons()
    {
        // Arrange
        var query = new GetLessonsQuery(null, null);

        var lesson = new Lesson(
            "Weather",
            "Learn about weather."
        );

        var lessons = new List<Lesson> { lesson };

        var repositoryMock = new Mock<ILessonRepository>();

        repositoryMock
            .Setup(repository => repository.GetLessonsAsync(
                null,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(lessons);

        var validatorMock = new Mock<IValidator<GetLessonsQuery>>();

        // validatorMock
        //     .Setup(validator => validator.ValidateAsync(
        //         It.IsAny<ValidationContext<GetLessonsQuery>>(),
        //         It.IsAny<CancellationToken>()))
        //     .ReturnsAsync(new ValidationResult());
        validatorMock
            .Setup(validator => validator.ValidateAsync(
                It.IsAny<GetLessonsQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());  

        var handler = new GetLessonsHandler(
            repositoryMock.Object,
            validatorMock.Object
        );

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        Assert.Single(result);
        Assert.Equal("Weather", result[0].Title);
        Assert.Equal("Learn about weather.", result[0].Description);
        Assert.Empty(result[0].TopicNames);
    }
}