using DooKamp.Domain.Entities.Curriculum;

namespace DooKamp.Domain.Entities.Lessons;

public sealed class LessonLocationGrade : Entity<int>
{
    private LessonLocationGrade() { }

    public LessonLocationGrade(
        int lessonId,
        int locationId,
        int gradeId)
    {
        LessonId = lessonId;
        LocationId = locationId;
        GradeId = gradeId;
    }

    public int LessonId { get; private set; }

    public int LocationId { get; private set; }

    public int GradeId { get; private set; }

    // Navigation Properties
    public Lesson Lesson { get; private set; } = null!;
    public Location Location { get; private set; } = null!;
    public Grade Grade { get; private set; } = null!;
}