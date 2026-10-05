using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Curriculum;

public class TopicConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Topics)
            .HasForeignKey(x => x.SubjectId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.ParentTopic)
            .WithMany(x => x.ChildTopics)
            .HasForeignKey(x => x.ParentTopicId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}