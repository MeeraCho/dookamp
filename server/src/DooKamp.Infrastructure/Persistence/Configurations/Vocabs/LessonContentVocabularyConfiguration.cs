using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Vocabs;

public class LessonContentVocabularyConfiguration
    : IEntityTypeConfiguration<LessonContentVocabulary>
{
    public void Configure(EntityTypeBuilder<LessonContentVocabulary> builder)
    {
        builder.HasOne(x => x.LessonContent)
            .WithMany(x => x.Vocabularies)
            .HasForeignKey(x => x.LessonContentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Vocabulary)
            .WithMany(x => x.LessonContentVocabularies)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.LessonContentId,
            x.VocabularyId
        })
        .IsUnique();
    }
}