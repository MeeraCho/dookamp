using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Lessons;

public class LessonLocationGradeConfiguration
    : IEntityTypeConfiguration<LessonLocationGrade>
{
    public void Configure(EntityTypeBuilder<LessonLocationGrade> builder)
    {
        builder.HasOne(x => x.Lesson)
            .WithMany(x => x.LessonLocationGrades)
            .HasForeignKey(x => x.LessonId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Location)
            .WithMany(x => x.LessonLocationGrades)
            .HasForeignKey(x => x.LocationId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(x => x.Grade)
            .WithMany(x => x.LessonLocationGrades)
            .HasForeignKey(x => x.GradeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(x => new
        {
            x.LessonId,
            x.LocationId,
            x.GradeId
        })
        .IsUnique();
    }
}