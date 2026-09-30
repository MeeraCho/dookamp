namespace DooKamp.Domain.Entities.Language;

public sealed class Language : Entity
{
    private Language() { }

    public Language(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public string Code { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;
}