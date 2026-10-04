using DooKamp.Domain.Entities.Audio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Audio;

public class VocabularyAudioConfiguration
    : IEntityTypeConfiguration<VocabularyAudio>
{
    public void Configure(EntityTypeBuilder<VocabularyAudio> builder)
    {
        builder.HasIndex(x => new
        {
            x.VocabularyId,
            x.LanguageId
        })
        .IsUnique();
    }
}