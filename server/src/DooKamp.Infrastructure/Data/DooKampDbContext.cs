using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Data;

public class DooKampDbContext : DbContext
{
    public DooKampDbContext(DbContextOptions<DooKampDbContext> options)
        : base(options)
    {
    }

    public DbSet<Lesson> Lessons => Set<Lesson>();
}