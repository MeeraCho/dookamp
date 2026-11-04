using DooKamp.Domain.Entities.Lessons;
using DooKamp.Domain.Entities.Topics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Data.Configurations.Lessons;

public class LessonTopicConfiguration : IEntityTypeConfiguration<TopicLesson>
{
    public void Configure(EntityTypeBuilder<TopicLesson> builder)
    {
        builder.HasKey(x => new
        {
            x.LessonId,
            x.TopicId
        });

        builder.HasOne(x => x.Topic)
            .WithMany(x => x.TopicLessons)
            .HasForeignKey(x => x.TopicId)
            .OnDelete(DeleteBehavior.Cascade);        

        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.TopicLessons)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}