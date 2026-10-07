using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Quizzes;

public class QuizQuestionAnswerConfiguration
    : IEntityTypeConfiguration<QuizQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<QuizQuestionAnswer> builder)
    {
        builder.Property(x => x.Answer)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasOne(x => x.QuizQuestion)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.QuizQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.QuizQuestionAnswers)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.QuizQuestionId,
            x.LanguageId,
            x.Answer
        })
        .IsUnique();
    }
}