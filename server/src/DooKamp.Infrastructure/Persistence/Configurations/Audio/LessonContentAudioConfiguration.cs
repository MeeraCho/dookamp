using DooKamp.Domain.Entities.Audio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Audio;

public class LessonContentAudioConfiguration
    : IEntityTypeConfiguration<LessonContentAudio>
{
    public void Configure(EntityTypeBuilder<LessonContentAudio> builder)
    {
        builder.HasIndex(x => new
        {
            x.LessonContentId,
            x.LanguageId
        })
        .IsUnique();
    }
}