using DooKamp.Domain.Entities.Media;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Media;

public class LessonContentMediaConfiguration
    : IEntityTypeConfiguration<LessonContentMedia>
{
    public void Configure(EntityTypeBuilder<LessonContentMedia> builder)
    {
        builder.HasOne(x => x.LessonContent)
            .WithMany(x => x.MediaItems)
            .HasForeignKey(x => x.LessonContentId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Media)
            .WithMany(x => x.LessonContentMedias)
            .HasForeignKey(x => x.MediaId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.LessonContentId,
            x.MediaId
        })
        .IsUnique();
    }
}