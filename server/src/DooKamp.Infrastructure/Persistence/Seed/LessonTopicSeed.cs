using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonTopicSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.LessonTopics.AnyAsync())
            return;

        // Topics
        var cellStructure = await context.Topics.SingleAsync(x => x.Name == "Cell Structure");
        var cellMembrane = await context.Topics.SingleAsync(x => x.Name == "Cell Membrane");
        var nucleus = await context.Topics.SingleAsync(x => x.Name == "Nucleus");
        var plantAndAnimalCells = await context.Topics.SingleAsync(x => x.Name == "Plant and Animal Cells");
        var organs = await context.Topics.SingleAsync(x => x.Name == "Organs");
        var tissues = await context.Topics.SingleAsync(x => x.Name == "Tissues");
        var bodyOrganization = await context.Topics.SingleAsync(x => x.Name == "Body Organization");
        var digestiveSystem = await context.Topics.SingleAsync(x => x.Name == "Digestive System");
        var respiratorySystem = await context.Topics.SingleAsync(x => x.Name == "Respiratory System");
        var circulatorySystem = await context.Topics.SingleAsync(x => x.Name == "Circulatory System");
        var nervousSystem = await context.Topics.SingleAsync(x => x.Name == "Nervous System");
        var skeletalSystem = await context.Topics.SingleAsync(x => x.Name == "Skeletal System");
        var plantStructure = await context.Topics.SingleAsync(x => x.Name == "Plant Structure");
        var photosynthesis = await context.Topics.SingleAsync(x => x.Name == "Photosynthesis");
        var plantReproduction = await context.Topics.SingleAsync(x => x.Name == "Plant Reproduction");
        var plantLifeCycles = await context.Topics.SingleAsync(x => x.Name == "Plant Life Cycles");

        // Lessons
        var cellStructure1 = await context.Lessons.SingleAsync(x => x.Title == "Introduction to Cell Structure");
        var cellStructure2 = await context.Lessons.SingleAsync(x => x.Title == "Inside a Cell");
        var cellStructure3 = await context.Lessons.SingleAsync(x => x.Title == "How Cell Parts Work Together");

        var cellMembrane1 = await context.Lessons.SingleAsync(x => x.Title == "The Cell Membrane");
        var cellMembrane2 = await context.Lessons.SingleAsync(x => x.Title == "What Enters and Leaves a Cell?");
        var cellMembrane3 = await context.Lessons.SingleAsync(x => x.Title == "The Cell Membrane and Cell Survival");

        var nucleus1 = await context.Lessons.SingleAsync(x => x.Title == "The Nucleus");
        var nucleus2 = await context.Lessons.SingleAsync(x => x.Title == "What Does the Nucleus Do?");
        var nucleus3 = await context.Lessons.SingleAsync(x => x.Title == "The Nucleus and Cell Functions");

        var plantAndAnimalCells1 = await context.Lessons.SingleAsync(x => x.Title == "Plant and Animal Cells");
        var plantAndAnimalCells2 = await context.Lessons.SingleAsync(x => x.Title == "Comparing Plant and Animal Cells");
        var plantAndAnimalCells3 = await context.Lessons.SingleAsync(x => x.Title == "What Makes Plant Cells Different?");

        var organsLesson = await context.Lessons.SingleAsync(x => x.Title == "Organs");
        var tissuesLesson = await context.Lessons.SingleAsync(x => x.Title == "Tissues");
        var bodyOrganizationLesson = await context.Lessons.SingleAsync(x => x.Title == "Body Organization");

        var digestiveSystemLesson = await context.Lessons.SingleAsync(x => x.Title == "The Digestive System");
        var respiratorySystemLesson = await context.Lessons.SingleAsync(x => x.Title == "The Respiratory System");
        var circulatorySystemLesson = await context.Lessons.SingleAsync(x => x.Title == "The Circulatory System");
        var nervousSystemLesson = await context.Lessons.SingleAsync(x => x.Title == "The Nervous System");
        var skeletalSystemLesson = await context.Lessons.SingleAsync(x => x.Title == "The Skeletal System");

        var plantStructureLesson = await context.Lessons.SingleAsync(x => x.Title == "Plant Structure");
        var photosynthesisLesson = await context.Lessons.SingleAsync(x => x.Title == "Photosynthesis");
        var plantReproductionLesson = await context.Lessons.SingleAsync(x => x.Title == "Plant Reproduction");
        var plantLifeCyclesLesson = await context.Lessons.SingleAsync(x => x.Title == "Plant Life Cycles");

        context.LessonTopics.AddRange(
            new LessonTopic(cellStructure1.Id, cellStructure.Id),
            new LessonTopic(cellStructure2.Id, cellStructure.Id),
            new LessonTopic(cellStructure3.Id, cellStructure.Id),

            new LessonTopic(cellMembrane1.Id, cellMembrane.Id),
            new LessonTopic(cellMembrane2.Id, cellMembrane.Id),
            new LessonTopic(cellMembrane3.Id, cellMembrane.Id),

            new LessonTopic(nucleus1.Id, nucleus.Id),
            new LessonTopic(nucleus2.Id, nucleus.Id),
            new LessonTopic(nucleus3.Id, nucleus.Id),

            new LessonTopic(plantAndAnimalCells1.Id, plantAndAnimalCells.Id),
            new LessonTopic(plantAndAnimalCells2.Id, plantAndAnimalCells.Id),
            new LessonTopic(plantAndAnimalCells3.Id, plantAndAnimalCells.Id),

            new LessonTopic(organsLesson.Id, organs.Id),
            new LessonTopic(tissuesLesson.Id, tissues.Id),
            new LessonTopic(bodyOrganizationLesson.Id, bodyOrganization.Id),

            new LessonTopic(digestiveSystemLesson.Id, digestiveSystem.Id),
            new LessonTopic(respiratorySystemLesson.Id, respiratorySystem.Id),
            new LessonTopic(circulatorySystemLesson.Id, circulatorySystem.Id),
            new LessonTopic(nervousSystemLesson.Id, nervousSystem.Id),
            new LessonTopic(skeletalSystemLesson.Id, skeletalSystem.Id),

            new LessonTopic(plantStructureLesson.Id, plantStructure.Id),
            new LessonTopic(photosynthesisLesson.Id, photosynthesis.Id),
            new LessonTopic(plantReproductionLesson.Id, plantReproduction.Id),
            new LessonTopic(plantLifeCyclesLesson.Id, plantLifeCycles.Id));

        await context.SaveChangesAsync();
    }
}