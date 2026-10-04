using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Quizzes;

public class QuizQuestionLanguageConfiguration
    : IEntityTypeConfiguration<QuizQuestionLanguage>
{
    public void Configure(EntityTypeBuilder<QuizQuestionLanguage> builder)
    {
        builder.HasOne(x => x.QuizQuestion)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.QuizQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.QuizQuestionLanguages)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.QuizQuestionId,
            x.LanguageId
        })
        .IsUnique();
    }
}