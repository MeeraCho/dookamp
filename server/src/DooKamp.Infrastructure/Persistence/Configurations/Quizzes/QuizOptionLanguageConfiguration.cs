using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Quizzes;

public class QuizOptionLanguageConfiguration
    : IEntityTypeConfiguration<QuizOptionLanguage>
{
    public void Configure(EntityTypeBuilder<QuizOptionLanguage> builder)
    {
        builder.HasOne(x => x.QuizOption)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.QuizOptionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.QuizOptionLanguages)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.QuizOptionId,
            x.LanguageId
        })
        .IsUnique();
    }
}