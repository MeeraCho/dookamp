using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class DbInitializer
{
    public static async Task InitializeAsync(
        DooKampDbContext context)
    {
        await context.Database.MigrateAsync();

        // ****** Seed *******
        //Curriculum 
        await LocationSeed.SeedAsync(context);
        await GradeSeed.SeedAsync(context);
        await LanguageSeed.SeedAsync(context);
        await SubjectSeed.SeedAsync(context);
        await TopicSeed.SeedAsync(context);
        
        //Lesson
        await LessonSeed.SeedAsync(context);
        await LessonTopicSeed.SeedAsync(context);
        await LessonLocationGradeSeed.SeedAsync(context);
        await LessonContentSeed.SeedAsync(context);
        await LessonContentLanguageSeed.SeedAsync(context);

        //Vocabulary
        await VocabularySeed.SeedAsync(context);
        await VocabularyLanguageSeed.SeedAsync(context);
        await LessonContentVocabularySeed.SeedAsync(context);
        
        //Quiz
        await QuestionTypeSeed.SeedAsync(context);
        await QuizQuestionSeed.SeedAsync(context);
        await QuizQuestionLanguageSeed.SeedAsync(context);
        await QuizQuestionAnswerSeed.SeedAsync(context);
        await QuizOptionSeed.SeedAsync(context);
        await QuizOptionLanguageSeed.SeedAsync(context);
    }
}