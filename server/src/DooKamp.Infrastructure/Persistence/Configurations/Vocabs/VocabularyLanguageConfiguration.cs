using DooKamp.Domain.Entities.Vocabs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Vocabs;

public class VocabularyLanguageConfiguration
    : IEntityTypeConfiguration<VocabularyLanguage>
{
    public void Configure(EntityTypeBuilder<VocabularyLanguage> builder)
    {
        builder.HasOne(x => x.Vocabulary)
            .WithMany(x => x.Languages)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Language)
            .WithMany(x => x.VocabularyLanguages)
            .HasForeignKey(x => x.LanguageId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.VocabularyId,
            x.LanguageId
        })
        .IsUnique();
    }
}