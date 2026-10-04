using DooKamp.Domain.Entities.Quizzes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Quizzes;

public class QuizOptionConfiguration
    : IEntityTypeConfiguration<QuizOption>
{
    public void Configure(EntityTypeBuilder<QuizOption> builder)
    {
        builder.HasOne(x => x.QuizQuestion)
            .WithMany(x => x.Options)
            .HasForeignKey(x => x.QuizQuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => new
        {
            x.QuizQuestionId,
            x.Order
        })
        .IsUnique();
    }
}