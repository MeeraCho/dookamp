using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dookamp.Infrastructure;

public sealed class LessonDbContextFactory : IDesignTimeDbContextFactory<LessonDbContext>
{
    public LessonDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<LessonDbContext>();
        optionsBuilder.UseSqlite("Data Source=dookamp.db");
        return new LessonDbContext(optionsBuilder.Options);
    }
}