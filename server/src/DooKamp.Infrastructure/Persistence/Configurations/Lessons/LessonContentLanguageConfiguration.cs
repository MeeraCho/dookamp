using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Lessons;

public class LessonContentLanguageConfiguration
    : IEntityTypeConfiguration<LessonContentLanguage>
{
    public void Configure(EntityTypeBuilder<LessonContentLanguage> builder)
    {
        builder.HasOne(x => x.LessonContent)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.LessonContentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.LessonContentLanguages)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.LessonContentId,
            x.LanguageId
        })
        .IsUnique();
    }
}