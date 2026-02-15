using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    private static Skill[] SeedSkills(CharacterContext context, Stat[] stats)
    {
        var skills = new Skill[]
        {
            new Skill
            {
                Name = "Acrobatics",
                Description = "A measure of your character's agility and balance.",
                StatId = stats[1].Id // Dexterity
            },
            new Skill
            {
                Name = "Animal Handling",
                Description = "A measure of your character's ability to handle animals.",
                StatId = stats[4].Id // Wisdom
            },
            new Skill
            {
                Name = "Arcana",
                Description = "A measure of your character's knowledge of magic and the arcane.",
                StatId = stats[3].Id // Intelligence
            },
            new Skill
            {
                Name = "Athletics",
                Description = "A measure of your character's physical prowess in climbing, jumping, and swimming.",
                StatId = stats[0].Id // Strength
            },
            new Skill
            {
                Name = "Deception",
                Description = "A measure of your character's ability to deceive others.",
                StatId = stats[5].Id // Charisma
            },
            new Skill
            {
                Name = "History",
                Description = "A measure of your character's knowledge of past events and lore.",
                StatId = stats[3].Id // Intelligence
            },
            new Skill
            {
                Name = "Insight",
                Description = "A measure of your character's ability to read people and situations.",
                StatId = stats[4].Id // Wisdom
            },
            new Skill
            {
                Name = "Intimidation",
                Description = "A measure of your character's ability to coerce or frighten others.",
                StatId = stats[5].Id // Charisma
            },
            new Skill
            {
                Name = "Investigation",
                Description = "A measure of your character's ability to search for clues and solve puzzles.",
                StatId = stats[3].Id // Intelligence
            },
            new Skill
            {
                Name = "Medicine",
                Description = "A measure of your character's ability to heal wounds and diagnose ailments.",
                StatId = stats[4].Id // Wisdom
            },
            new Skill
            {
                Name = "Nature",
                Description = "A measure of your character's knowledge of the natural world.",
                StatId = stats[3].Id // Intelligence
            },
            new Skill
            {
                Name = "Perception",
                Description = "A measure of your character's awareness of their surroundings.",
                StatId = stats[4].Id // Wisdom
            },
            new Skill
            {
                Name = "Performance",
                Description = "A measure of your character's ability to entertain others.",
                StatId = stats[5].Id // Charisma
            },
            new Skill
            {
                Name = "Persuasion",
                Description = "A measure of your character's ability to influence others through argument or charm.",
                StatId = stats[5].Id // Charisma
            },
            new Skill
            {
                Name = "Religion",
                Description = "A measure of your character's knowledge of religious lore and practices.",
                StatId = stats[3].Id // Intelligence
            },
            new Skill
            {
                Name = "Sleight of Hand",
                Description = "A measure of your character's ability to perform tricks and manipulate objects.",
                StatId = stats[1].Id // Dexterity
            },
            new Skill
            {
                Name = "Stealth",
                Description = "A measure of your character's ability to move silently and avoid detection.",
                StatId = stats[1].Id // Dexterity
            },
            new Skill
            {
                Name = "Survival",
                Description = "A measure of your character's ability to survive in the wilderness.",
                StatId = stats[4].Id // Wisdom
            }
        };
        context.Skills.AddRange(skills);
        context.SaveChanges();

        return skills;
    }
}
