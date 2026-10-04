using DooKamp.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Media;

public class VocabularyMediaConfiguration
    : IEntityTypeConfiguration<VocabularyMedia>
{
    public void Configure(EntityTypeBuilder<VocabularyMedia> builder)
    {
        builder.HasOne(x => x.Vocabulary)
            .WithMany(x => x.VocabularyMedias)
            .HasForeignKey(x => x.VocabularyId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Media)
            .WithMany(x => x.VocabularyMedias)
            .HasForeignKey(x => x.MediaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.VocabularyId,
            x.MediaId
        })
        .IsUnique();
    }
}