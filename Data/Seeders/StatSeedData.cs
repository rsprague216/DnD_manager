using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    private static Stat[] SeedStats(CharacterContext context)
    {
        var stats = new Stat[]
        {
            new Stat
            {
                Name = "Strength",
                Description = "A measure of your character's physical power."
            },
            new Stat
            {
                Name = "Dexterity",
                Description = "A measure of your character's agility and reflexes."
            },
            new Stat
            {
                Name = "Constitution",
                Description = "A measure of your character's health and stamina."
            },
            new Stat
            {
                Name = "Intelligence",
                Description = "A measure of your character's mental acuity and reasoning."
            },
            new Stat
            {
                Name = "Wisdom",
                Description = "A measure of your character's willpower and common sense."
            },
            new Stat
            {
                Name = "Charisma",
                Description = "A measure of your character's force of personality and social skills."
            }
        };
        context.Stats.AddRange(stats);
        context.SaveChanges();

        return stats;
    }
}
