using DooKamp.Domain.Entities.Media;
using DooKamp.Domain.Entities.Audio;

namespace DooKamp.Domain.Entities.Vocabs;

public sealed class Vocabulary : Entity<int>
{
    private Vocabulary() { }
    public Vocabulary(string code)
    {
        Code = code;
    }

    public string Code { get; private set; } = string.Empty;

    public IReadOnlyCollection<LessonContentVocabulary> LessonContentVocabularies
        { get; private set; } = new List<LessonContentVocabulary>();

    public IReadOnlyCollection<VocabularyLanguage> Languages
        { get; private set; } = new List<VocabularyLanguage>();

    public IReadOnlyCollection<VocabularyAudio> Audios
        { get; private set; } = new List<VocabularyAudio>();

    public IReadOnlyCollection<VocabularyMedia> VocabularyMedias
        { get; private set; } = new List<VocabularyMedia>();
}