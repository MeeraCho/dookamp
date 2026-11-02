using DooKamp.Application.Exceptions;
using DooKamp.Application.Features.Lessons.GetLessons;
using DooKamp.Application.Interfaces.Lessons;
using DooKamp.Application.Validators;
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

        // Sample data
        var lessons = new List<Lesson>
        {
            new Lesson("Weather","Learn about weather"),
            new Lesson("Cell Structure", "Learn about cells"),
        };

        // Mock dependencies
        var repositoryMock = new Mock<ILessonRepository>();
        var validatorMock = new Mock<IValidator<GetLessonsQuery>>();

        // Configure repository mock to return sample lessons.
        repositoryMock
            .Setup(repository => repository.GetLessonsAsync(
                null,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(lessons);

        // Configure validator mock to return a valid result.
        validatorMock
            .Setup(validator => validator.ValidateAsync(
                It.IsAny<GetLessonsQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());  

        // Create handler with mocked dependencies.
        var handler = new GetLessonsHandler(
            repositoryMock.Object,
            validatorMock.Object
        );

        // Act
        var result = await handler.HandleAsync(query);

        // Assert
        Assert.Equal("Weather", result[0].Title); 
        Assert.Equal("Learn about weather", result[0].Description); 
        Assert.Equal("Cell Structure", result[1].Title); 
        Assert.Equal("Learn about cells", result[1].Description); 
        Assert.Empty(result[0].TopicNames);
        Assert.Empty(result[1].TopicNames);
    }

    [Fact]
    public async Task HandleAsync_ValidQueryWithNoLessons_ReturnEmptyList()
    {
        //Arrange
        var query = new GetLessonsQuery(null, null);

        // No Sample data

        // Repository mock to return an empty list.
        var repositoryMock = new Mock<ILessonRepository>();
        repositoryMock
            .Setup(repository => repository.GetLessonsAsync(
                null,
                null,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Lesson>());        

        // Validator mock to return a valid result.
        var validatorMock = new Mock<IValidator<GetLessonsQuery>>();
        validatorMock
            .Setup(validator => validator.ValidateAsync(
                It.IsAny<GetLessonsQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());  
        
        // GetLessonsHandler instance with mocked dependencies.
        var handler = new GetLessonsHandler(
            repositoryMock.Object,
            validatorMock.Object
        );

        //Act
        var result = await handler.HandleAsync(query);

        //Assert
        Assert.NotNull(result);
        Assert.Empty(result);        
    }

    [Fact]
    public async Task HandleAsync_ValidQuery_PassesFiltersToRepository()
    {
        // Arrange
        var query = new GetLessonsQuery(1, 5);

            // repositoryMock
        var repositoryMock = new Mock<ILessonRepository>();
        repositoryMock
            .Setup(repository => repository.GetLessonsAsync(
                1,
                5,
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new List<Lesson>());

            // validatorMock
        var validatorMock = new Mock<IValidator<GetLessonsQuery>>();
        validatorMock
            .Setup(validator => validator.ValidateAsync(
                It.IsAny<GetLessonsQuery>(),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

            // GetLessonsHandler instance
        var handler = new GetLessonsHandler(
            repositoryMock.Object, 
            validatorMock.Object);

        // Act - when GetLessonsAsync called return empty List and then transform empty List dto, finally return empty List dto 
        await handler.HandleAsync(query);
        

        // Assert - Handler가 Repository에 1, 5를 전달해서 정확히 한 번 호출했는지 확인
        repositoryMock.Verify(
            repository => repository.GetLessonsAsync(
                1,
                5,
                It.IsAny<CancellationToken>()),
            Times.Once);
    }
    
    [Fact]
    public async Task HandleAsync_InvalidLocationId_ThrowsApplicationValidationException()
    {
        // Arrange
        var query = new GetLessonsQuery(0, 5);

        var repositoryMock = new Mock<ILessonRepository>();

        var validator = new GetLessonsQueryValidator();

        var handler = new GetLessonsHandler( repositoryMock.Object, validator);

        // Act & Assert
        // Verify that invalid input throws an ApplicationValidationException.
        await Assert.ThrowsAsync<ApplicationValidationException>(
            () => handler.HandleAsync(query));

        // Verify that the repository is never called when validation fails.
        repositoryMock.Verify(
            repository => repository.GetLessonsAsync(
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }

    [Fact]
    public async Task HandleAsync_InvalidGradeId_ThrowsApplicationValidationException()
    {
        // Arrange
        var query = new GetLessonsQuery(1, 0);

        var repositoryMock = new Mock<ILessonRepository>();

        var validator = new GetLessonsQueryValidator();

        var handler = new GetLessonsHandler( repositoryMock.Object, validator);

        // Act & Assert
        // Verify that invalid input throws an ApplicationValidationException.
        await Assert.ThrowsAsync<ApplicationValidationException>(
            () => handler.HandleAsync(query));

        // Verify that the repository is never called when validation fails.
        repositoryMock.Verify(
            repository => repository.GetLessonsAsync(
                It.IsAny<int?>(),
                It.IsAny<int?>(),
                It.IsAny<CancellationToken>()),
            Times.Never);
    }

}