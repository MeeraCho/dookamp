namespace DooKamp.Application.DTOs.Lessons;

public sealed class VocabularyDto
{
    public int Id { get; init; }

    public string Word { get; init; } = string.Empty;

    public string Definition { get; init; } = string.Empty;

    public string LanguageCode { get; init; } = string.Empty;
}