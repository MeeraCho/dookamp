using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Lessons;

public class TopicLocationGradeConfiguration
    : IEntityTypeConfiguration<TopicLocationGrade>
{
    public void Configure(EntityTypeBuilder<TopicLocationGrade> builder)
    {
        builder.HasOne(x => x.Topic)
            .WithMany(x => x.TopicLocationGrades)
            .HasForeignKey(x => x.TopicId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Location)
            .WithMany(x => x.TopicLocationGrades)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.TopicLocationGrades)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.TopicId,
            x.LocationId,
            x.GradeId
        })
        .IsUnique();
    }
}