namespace DooKamp.Domain.Entities.Curriculum;

public sealed class Subject : Entity<int>
{
    private Subject() { }

    public Subject(string name)
    {
        Name = name;
    }

    public string Name { get; private set; } = string.Empty;
}