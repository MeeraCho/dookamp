using DooKamp.Application.Interfaces.Grades;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Repositories.Grades;

public sealed class GradeRepository(DooKampDbContext context) : IGradeRepository
{
    public async Task<IReadOnlyList<Grade>> GetGradesAsync(
        CancellationToken cancellationToken = default)
    {
        return await context.Grades //Db Set 이름이 Grades인지 확인 
            .AsNoTracking()
            .OrderBy(grade => grade.Name)
            .ToListAsync(cancellationToken);
    }
}