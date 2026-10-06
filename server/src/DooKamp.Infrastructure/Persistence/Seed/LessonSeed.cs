using DooKamp.Domain.Entities.Lessons;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class LessonSeed
{
    public static async Task SeedAsync(DooKampDbContext context)
    {
        if (await context.Lessons.AnyAsync())
            return;
        
        // Cells
        var cellStructure1 = new Lesson("Introduction to Cell Structure", "Learn about the basic parts and structure of a cell.");
        var cellStructure2 = new Lesson("Inside a Cell", "Explore the main parts of a cell and what each part does.");
        var cellStructure3 = new Lesson("How Cell Parts Work Together", "Learn how different parts of a cell work together to keep it alive.");

        var cellMembrane1 = new Lesson("The Cell Membrane", "Learn how the cell membrane protects the cell and controls what enters and leaves.");
        var cellMembrane2 = new Lesson("What Enters and Leaves a Cell?", "Learn how materials move into and out of cells.");
        var cellMembrane3 = new Lesson("The Cell Membrane and Cell Survival", "Learn why the cell membrane is important for keeping a cell alive.");

        var nucleus1 = new Lesson("The Nucleus", "Learn about the nucleus and its role in controlling cell activities.");
        var nucleus2 = new Lesson("What Does the Nucleus Do?", "Learn how the nucleus stores information and helps control the cell.");
        var nucleus3 = new Lesson("The Nucleus and Cell Functions", "Learn how the nucleus helps cells grow, work, and reproduce.");

        var plantAndAnimalCells1 = new Lesson("Plant and Animal Cells", "Learn about the similarities and differences between plant and animal cells.");
        var plantAndAnimalCells2 = new Lesson("Comparing Plant and Animal Cells", "Compare the structures and functions of plant and animal cells.");
        var plantAndAnimalCells3 = new Lesson("What Makes Plant Cells Different?", "Learn about the cell parts that make plant cells different from animal cells.");

        // Human Body
        var organs = new Lesson("Organs", "Learn about organs and the important jobs they do in the human body.");
        var tissues = new Lesson("Tissues", "Learn how groups of similar cells work together to form tissues.");
        var bodyOrganization = new Lesson("Body Organization", "Learn how cells, tissues, organs, and body systems are organized.");

        // Body Systems
        var digestiveSystem = new Lesson("The Digestive System", "Learn how the digestive system breaks down food and provides nutrients.");
        var respiratorySystem = new Lesson("The Respiratory System", "Learn how the respiratory system brings oxygen into the body.");
        var circulatorySystem = new Lesson("The Circulatory System", "Learn how blood carries oxygen and nutrients throughout the body.");
        var nervousSystem = new Lesson("The Nervous System", "Learn how the nervous system receives information and controls the body.");
        var skeletalSystem = new Lesson("The Skeletal System", "Learn how bones support and protect the body.");

        // Plants
        var plantStructure = new Lesson("Plant Structure", "Learn about the main parts of a plant and their functions.");
        var photosynthesis = new Lesson("Photosynthesis", "Learn how plants use light, water, and carbon dioxide to make food.");
        var plantReproduction = new Lesson("Plant Reproduction", "Learn how plants reproduce and create new plants.");
        var plantLifeCycles = new Lesson("Plant Life Cycles", "Learn about the stages of a plant's life cycle.");

        context.Lessons.AddRange(
            cellStructure1, cellStructure2, cellStructure3,
            cellMembrane1, cellMembrane2, cellMembrane3,
            nucleus1, nucleus2, nucleus3,
            plantAndAnimalCells1, plantAndAnimalCells2, plantAndAnimalCells3,   
            organs, tissues, bodyOrganization,
            digestiveSystem, respiratorySystem, circulatorySystem, nervousSystem, skeletalSystem,
            plantStructure, photosynthesis, plantReproduction, plantLifeCycles);

        await context.SaveChangesAsync();
    }
}