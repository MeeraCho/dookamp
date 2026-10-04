using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DooKamp.Infrastructure.Persistence.Configurations.Curriculum;
public class GradeConfiguration : IEntityTypeConfiguration<Grade>
{
    public void Configure(EntityTypeBuilder<Grade> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(g => g.Name)
            .IsRequired()
            .HasMaxLength(100);
            
        builder.HasIndex(x => x.Name)
            .IsUnique();
    }
}