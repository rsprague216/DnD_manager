using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    private static Race[] SeedRaces(CharacterContext context)
    {
        var races = new Race[]
        {
            new Race
            {   // 0
                Name = "Human",
                Size = "Medium",
                Speed = 30,
                MaxAge = 80,
                Languages = new List<string> { "Common", "Any one language" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 1
                Name = "Elf",
                Size = "Medium",
                Speed = 30,
                MaxAge = 750,
                Languages = new List<string> { "Common", "Elvish" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 2
                Name = "Aasimar",
                Size = "Medium",
                Speed = 30,
                MaxAge = 160,
                Languages = new List<string> { "Common", "Celestial" },
                Source = "Volo's Guide to Monsters"
            },
            new Race
            {   // 3
                Name = "Tiefling",
                Size = "Medium",
                Speed = 30,
                MaxAge = 120,
                Languages = new List<string> { "Common", "Infernal" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 4
                Name = "Half-Elf",
                Size = "Medium",
                Speed = 30,
                MaxAge = 180,
                Languages = new List<string> { "Common", "Elvish" },
                Source = "Player's Handbook"
            }
        };
        context.Races.AddRange(races);
        context.SaveChanges();

        return races;
    }

    private static void SeedSubraces(CharacterContext context, Race[] races)
    {
        var subraces = new Subrace[]
        {
            new Subrace
            {   // 0
                Name = "High Elf",
                Description = "High Elves are known for their keen senses and mastery of magic.",
                RaceId = races[1].Id
            },
            new Subrace
            {   // 1
                Name = "Wood Elf",
                Description = "Wood Elves are known for their agility and connection to nature.",
                RaceId = races[1].Id
            },
            new Subrace
            {   // 2
                Name = "Drow",
                Description = "Drow are known for their darkvision and innate magic.",
                RaceId = races[1].Id
            },
            new Subrace
            {   // 3
                Name = "Variant Human",
                Description = "Variant Humans are known for their adaptability and versatility.",
                RaceId = races[0].Id
            }
        };
        context.Subraces.AddRange(subraces);
        context.SaveChanges();
    }
}
