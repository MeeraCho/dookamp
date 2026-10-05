using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Data.Configurations.Lessons;

public class LessonTopicConfiguration : IEntityTypeConfiguration<LessonTopic>
{
    public void Configure(EntityTypeBuilder<LessonTopic> builder)
    {
        builder.HasKey(x => new
        {
            x.LessonId,
            x.TopicId
        });

        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.LessonTopics)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Topic)
            .WithMany(x => x.LessonTopics)
            .HasForeignKey(x => x.TopicId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}