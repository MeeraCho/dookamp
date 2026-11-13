namespace DooKamp.Application.DTOs.Languages;

public sealed class LanguageListDto
{
    public int Id { get; set; }

    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}