using DooKamp.Domain.Entities.Lessons;
namespace DooKamp.Domain.Entities.Curriculum;

public sealed class Location : Entity<int>
{
    private Location() { }

    public Location(
        string name,
        string code,
        string country)
    {
        Name = name;
        Code = code;
        Country = country;
    }

    public string Name { get; private set; } = string.Empty;

    public string Code { get; private set; } = string.Empty;

    public string Country { get; private set; } = string.Empty;

    public IReadOnlyCollection<LessonLocationGrade> LessonLocationGrades 
		{ get; private set; } = new List<LessonLocationGrade>();
}