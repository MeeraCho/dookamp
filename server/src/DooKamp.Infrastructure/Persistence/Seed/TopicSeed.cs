using DooKamp.Domain.Entities.Curriculum;
using Microsoft.EntityFrameworkCore;

namespace DooKamp.Infrastructure.Persistence.Seed;

public static class TopicSeed
{
    public static async Task SeedAsync(
        DooKampDbContext context)
    {
        if (await context.Topics.AnyAsync())
            return;

        var science = await context.Subjects.SingleAsync(x => x.Name == "Science");

        // Top-level topics
        var biology = new Topic("Biology", science.Id);
        var chemistry = new Topic("Chemistry", science.Id);
        var physics = new Topic("Physics", science.Id);
        var earthAndSpaceScience = new Topic("Earth and Space Science", science.Id);

        context.Topics.AddRange(biology, chemistry, physics, earthAndSpaceScience);
        await context.SaveChangesAsync();

        // Biology
        var cells = new Topic("Cells", science.Id, biology.Id, "Learn about the basic structure and function of cells.");
        var humanBody = new Topic("Human Body", science.Id, biology.Id, "Learn about the main parts and organization of the human body.");
        var bodySystems = new Topic("Body Systems", science.Id, biology.Id, "Learn how different body systems work together.");
        var plants = new Topic("Plants", science.Id, biology.Id, "Learn about plant structures, growth, and how plants make food.");
        var animals = new Topic("Animals", science.Id, biology.Id, "Learn about animal groups, structures, and life cycles.");
        var animalAdaptations = new Topic("Animal Adaptations", science.Id, biology.Id, "Learn how animals adapt to survive in their environments.");
        var ecosystems = new Topic("Ecosystems", science.Id, biology.Id, "Learn how living things interact with their environments.");
        var foodChainsAndFoodWebs = new Topic("Food Chains and Food Webs", science.Id, biology.Id, "Learn how energy moves through food chains and food webs.");
        var biodiversity = new Topic("Biodiversity", science.Id, biology.Id, "Learn about the variety of living things in different environments.");
        var geneticsAndHeredity = new Topic("Genetics and Heredity", science.Id, biology.Id, "Learn how traits are passed from parents to offspring.");

        context.Topics.AddRange(cells, humanBody, bodySystems, plants, animals, animalAdaptations, ecosystems, foodChainsAndFoodWebs, biodiversity, geneticsAndHeredity);

        await context.SaveChangesAsync();

        // Chemistry
        var matter = new Topic("Matter", science.Id, chemistry.Id, "Learn what matter is and what it is made of.");
        var propertiesOfMatter = new Topic("Properties of Matter", science.Id, chemistry.Id, "Learn about the physical and chemical properties of matter.");
        var statesOfMatter = new Topic("States of Matter", science.Id, chemistry.Id, "Learn about solids, liquids, gases, and how matter changes state.");
        var physicalAndChemicalChanges = new Topic("Physical and Chemical Changes", science.Id, chemistry.Id, "Learn how matter can change physically or chemically.");
        var mixturesAndSolutions = new Topic("Mixtures and Solutions", science.Id, chemistry.Id, "Learn how substances combine to form mixtures and solutions.");
        var chemicalReactions = new Topic("Chemical Reactions", science.Id, chemistry.Id, "Learn how substances change during chemical reactions.");

        context.Topics.AddRange(matter, propertiesOfMatter, statesOfMatter, physicalAndChemicalChanges, mixturesAndSolutions, chemicalReactions);
        await context.SaveChangesAsync();


        // Physics
        var forcesAndMotion = new Topic("Forces and Motion", science.Id, physics.Id, "Learn how forces affect the motion of objects.");
        var energy = new Topic("Energy", science.Id, physics.Id, "Learn about different forms of energy and how energy moves.");
        var electricity = new Topic("Electricity", science.Id, physics.Id, "Learn how electricity works and how electric circuits are made.");
        var magnetism = new Topic("Magnetism", science.Id, physics.Id, "Learn about magnets, magnetic forces, and magnetic fields.");
        var light = new Topic("Light", science.Id, physics.Id, "Learn how light travels, reflects, and changes direction.");
        var sound = new Topic("Sound", science.Id, physics.Id, "Learn how sound is produced and how it travels.");
        var simpleMachines = new Topic("Simple Machines", science.Id, physics.Id, "Learn how simple machines make work easier.");

        context.Topics.AddRange(forcesAndMotion, energy, electricity, magnetism, light, sound, simpleMachines);
        await context.SaveChangesAsync();


        // Earth and Space Science
        var weather = new Topic("Weather", science.Id, earthAndSpaceScience.Id, "Learn about daily weather conditions and patterns.");
        var climate = new Topic("Climate", science.Id, earthAndSpaceScience.Id, "Learn about long-term weather patterns in different regions.");
        var earthsStructure = new Topic("Earth's Structure", science.Id, earthAndSpaceScience.Id, "Learn about the layers and structure of Earth.");
        var rocksAndMinerals = new Topic("Rocks and Minerals", science.Id, earthAndSpaceScience.Id, "Learn about different types of rocks and minerals.");
        var spaceAndTheSolarSystem = new Topic("Space and the Solar System", science.Id, earthAndSpaceScience.Id, "Learn about the Sun, planets, Moon, and our solar system.");

        context.Topics.AddRange(weather, climate, earthsStructure, rocksAndMinerals, spaceAndTheSolarSystem);
        await context.SaveChangesAsync();


        // Biology Subtopics
        // Cells
        context.Topics.AddRange(
            new Topic("Cell Structure", science.Id, cells.Id),
            new Topic("Cell Membrane", science.Id, cells.Id),
            new Topic("Nucleus", science.Id, cells.Id),
            new Topic("Plant and Animal Cells", science.Id, cells.Id)
        );

        // Human Body
        context.Topics.AddRange(
            new Topic("Organs", science.Id, humanBody.Id),
            new Topic("Tissues", science.Id, humanBody.Id),
            new Topic("Body Organization", science.Id, humanBody.Id)
        );

        // Body Systems
        context.Topics.AddRange(
            new Topic("Digestive System", science.Id, bodySystems.Id),
            new Topic("Respiratory System", science.Id, bodySystems.Id),
            new Topic("Circulatory System", science.Id, bodySystems.Id),
            new Topic("Nervous System", science.Id, bodySystems.Id),
            new Topic("Skeletal System", science.Id, bodySystems.Id)
        );

        // Plants
        context.Topics.AddRange(
            new Topic("Plant Structure", science.Id, plants.Id),
            new Topic("Photosynthesis", science.Id, plants.Id),
            new Topic("Plant Reproduction", science.Id, plants.Id),
            new Topic("Plant Life Cycles", science.Id, plants.Id)
        );

        // Animals
        context.Topics.AddRange(
            new Topic("Animal Classification", science.Id, animals.Id),
            new Topic("Vertebrates", science.Id, animals.Id),
            new Topic("Invertebrates", science.Id, animals.Id),
            new Topic("Animal Life Cycles", science.Id, animals.Id)
        );

        // Animal Adaptations
        context.Topics.AddRange(
            new Topic("Physical Adaptations", science.Id, animalAdaptations.Id),
            new Topic("Behavioral Adaptations", science.Id, animalAdaptations.Id),
            new Topic("Adaptation and Survival", science.Id, animalAdaptations.Id)
        );

        // Ecosystems
        context.Topics.AddRange(
            new Topic("Habitats", science.Id, ecosystems.Id),
            new Topic("Producers and Consumers", science.Id, ecosystems.Id),
            new Topic("Biotic and Abiotic Factors", science.Id, ecosystems.Id),
            new Topic("Ecosystem Interactions", science.Id, ecosystems.Id)
        );

        // Food Chains and Food Webs
        context.Topics.AddRange(
            new Topic("Producers", science.Id, foodChainsAndFoodWebs.Id),
            new Topic("Consumers", science.Id, foodChainsAndFoodWebs.Id),
            new Topic("Decomposers", science.Id, foodChainsAndFoodWebs.Id),
            new Topic("Energy Flow", science.Id, foodChainsAndFoodWebs.Id)
        );

        // Biodiversity
        context.Topics.AddRange(
            new Topic("Species Diversity", science.Id, biodiversity.Id),
            new Topic("Genetic Diversity", science.Id, biodiversity.Id),
            new Topic("Ecosystem Diversity", science.Id, biodiversity.Id)
        );

        // Genetics and Heredity
        context.Topics.AddRange(
            new Topic("Genes", science.Id, geneticsAndHeredity.Id),
            new Topic("Traits", science.Id, geneticsAndHeredity.Id),
            new Topic("Heredity", science.Id, geneticsAndHeredity.Id),
            new Topic("Genetic Variation", science.Id, geneticsAndHeredity.Id)
        );

        await context.SaveChangesAsync();

        // Chemistry Subtopics
        // Matter
        context.Topics.AddRange(
            new Topic("Mass", science.Id, matter.Id),
            new Topic("Volume", science.Id, matter.Id),
            new Topic("Density", science.Id, matter.Id)
        );

        // Properties of Matter
        context.Topics.AddRange(
            new Topic("Physical Properties", science.Id, propertiesOfMatter.Id),
            new Topic("Chemical Properties", science.Id, propertiesOfMatter.Id)
        );

        // States of Matter
        context.Topics.AddRange(
            new Topic("Solids", science.Id, statesOfMatter.Id),
            new Topic("Liquids", science.Id, statesOfMatter.Id),
            new Topic("Gases", science.Id, statesOfMatter.Id),
            new Topic("Changes of State", science.Id, statesOfMatter.Id)
        );

        // Physical and Chemical Changes
        context.Topics.AddRange(
            new Topic("Physical Changes", science.Id, physicalAndChemicalChanges.Id),
            new Topic("Chemical Changes", science.Id, physicalAndChemicalChanges.Id)
        );

        // Mixtures and Solutions
        context.Topics.AddRange(
            new Topic("Mixtures", science.Id, mixturesAndSolutions.Id),
            new Topic("Solutions", science.Id, mixturesAndSolutions.Id),
            new Topic("Solubility", science.Id, mixturesAndSolutions.Id)
        );

        // Chemical Reactions
        context.Topics.AddRange(
            new Topic("Reactants and Products", science.Id, chemicalReactions.Id),
            new Topic("Evidence of Chemical Reactions", science.Id, chemicalReactions.Id)
        );

        await context.SaveChangesAsync();

        // Physics Subtopics
        // Forces and Motion
        context.Topics.AddRange(
            new Topic("Pushes and Pulls", science.Id, forcesAndMotion.Id),
            new Topic("Friction", science.Id, forcesAndMotion.Id),
            new Topic("Gravity", science.Id, forcesAndMotion.Id),
            new Topic("Speed and Motion", science.Id, forcesAndMotion.Id)
        );

        // Energy
        context.Topics.AddRange(
            new Topic("Forms of Energy", science.Id, energy.Id),
            new Topic("Potential and Kinetic Energy", science.Id, energy.Id),
            new Topic("Energy Transfer", science.Id, energy.Id)
        );

        // Electricity
        context.Topics.AddRange(
            new Topic("Electric Circuits", science.Id, electricity.Id),
            new Topic("Conductors and Insulators", science.Id, electricity.Id),
            new Topic("Series and Parallel Circuits", science.Id, electricity.Id)
        );

        // Magnetism
        context.Topics.AddRange(
            new Topic("Magnetic Fields", science.Id, magnetism.Id),
            new Topic("Magnetic Forces", science.Id, magnetism.Id),
            new Topic("Magnets and Materials", science.Id, magnetism.Id)
        );

        // Light
        context.Topics.AddRange(
            new Topic("Reflection", science.Id, light.Id),
            new Topic("Refraction", science.Id, light.Id),
            new Topic("Shadows", science.Id, light.Id)
        );

        // Sound
        context.Topics.AddRange(
            new Topic("Sound Waves", science.Id, sound.Id),
            new Topic("Pitch", science.Id, sound.Id),
            new Topic("Volume", science.Id, sound.Id),
            new Topic("Vibration", science.Id, sound.Id)
        );

        // Simple Machines
        context.Topics.AddRange(
            new Topic("Levers", science.Id, simpleMachines.Id),
            new Topic("Pulleys", science.Id, simpleMachines.Id),
            new Topic("Wheels and Axles", science.Id, simpleMachines.Id),
            new Topic("Inclined Planes", science.Id, simpleMachines.Id)
        );

        await context.SaveChangesAsync();

        // Earth and Space Science Subtopics
        // Weather
        context.Topics.AddRange(
            new Topic("Weather Patterns", science.Id, weather.Id),
            new Topic("Temperature", science.Id, weather.Id),
            new Topic("Precipitation", science.Id, weather.Id),
            new Topic("Clouds", science.Id, weather.Id)
        );

        // Climate
        context.Topics.AddRange(
            new Topic("Climate Zones", science.Id, climate.Id),
            new Topic("Climate Patterns", science.Id, climate.Id),
            new Topic("Climate Change", science.Id, climate.Id)
        );

        // Earth's Structure
        context.Topics.AddRange(
            new Topic("Crust", science.Id, earthsStructure.Id),
            new Topic("Mantle", science.Id, earthsStructure.Id),
            new Topic("Core", science.Id, earthsStructure.Id),
            new Topic("Tectonic Plates", science.Id, earthsStructure.Id)
        );

        // Rocks and Minerals
        context.Topics.AddRange(
            new Topic("Types of Rocks", science.Id, rocksAndMinerals.Id),
            new Topic("Rock Cycle", science.Id, rocksAndMinerals.Id),
            new Topic("Mineral Properties", science.Id, rocksAndMinerals.Id)
        );

        await context.SaveChangesAsync();
    }
}