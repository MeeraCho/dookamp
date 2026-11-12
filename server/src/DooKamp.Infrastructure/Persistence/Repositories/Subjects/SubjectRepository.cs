
using DooKamp.Application.Interfaces.Subjects;
using DooKamp.Domain.Entities.Curriculum;
using DooKamp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

public sealed class SubjectRepository : ISubjectRepository
{
    private readonly DooKampDbContext _context;

    public SubjectRepository(DooKampDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Subject>> GetSubjectsAsync(
        int? locationId,
        int? gradeId,
        CancellationToken cancellationToken = default)
    {
        var query = _context.Subjects
            .AsNoTracking()
            .AsQueryable();

        if (locationId.HasValue || gradeId.HasValue)
        {
            query = query.Where(subject =>
                subject.Topics.Any(topic =>
                    topic.TopicLocationGrades.Any(topicLocationGrade =>
                        (!locationId.HasValue ||
                            topicLocationGrade.LocationId == locationId.Value)
                        &&
                        (!gradeId.HasValue ||
                            topicLocationGrade.GradeId == gradeId.Value)
                    )
                )
            );
        }

        return await query
            .OrderBy(subject => subject.Name)
            .ToListAsync(cancellationToken);
    }
}
