using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Quizzes;

public class QuizQuestionConfiguration
    : IEntityTypeConfiguration<QuizQuestion>
{
    public void Configure(EntityTypeBuilder<QuizQuestion> builder)
    {
        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.QuizQuestions)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.LessonContent)
            .WithMany(x => x.QuizQuestions)
            .HasForeignKey(x => x.LessonContentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.QuestionType)
            .WithMany(x => x.QuizQuestions)
            .HasForeignKey(x => x.QuestionTypeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}