namespace DooKamp.Domain.Entities.Curriculum;
public sealed class Grade : Entity
{
    private Grade() { }
    public Grade(string name)
    {
        Name = name;
    }

    public string Name {get; private set;} = string.Empty;
}