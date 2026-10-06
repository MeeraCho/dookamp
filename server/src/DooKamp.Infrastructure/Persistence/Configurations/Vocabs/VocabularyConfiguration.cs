using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Vocabs;

public class VocabularyConfiguration
    : IEntityTypeConfiguration<Vocabulary>
{
    public void Configure(EntityTypeBuilder<Vocabulary> builder)
    {
        builder.Property(x => x.Code)
            .IsRequired()
            .HasMaxLength(100);

        builder.HasIndex(x => x.Code)
            .IsUnique();
            
        builder.HasMany(x => x.LessonContentVocabularies)
            .WithOne(x => x.Vocabulary)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Languages)
            .WithOne(x => x.Vocabulary)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Audios)
            .WithOne(x => x.Vocabulary)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.VocabularyMedias)
            .WithOne(x => x.Vocabulary)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}