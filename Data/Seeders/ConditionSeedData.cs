using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    private static Condition[] SeedConditions(CharacterContext context)
    {
        var conditions = new Condition[]
        {
            new Condition
            {
                Name = "Blinded",
                Description = "A blinded creature can't see and automatically fails any ability check that requires sight."
            },
            new Condition
            {
                Name = "Charmed",
                Description = "A charmed creature can't attack the charmer or target the charmer with harmful abilities or magical effects."
            },
            new Condition
            {
                Name = "Deafened",
                Description = "A deafened creature can't hear and automatically fails any ability check that requires hearing."
            },
            new Condition
            {
                Name = "Frightened",
                Description = "A frightened creature has disadvantage on ability checks and attack rolls while the source of its fear is within line of sight."
            },
            new Condition
            {
                Name = "Grappled",
                Description = "A grappled creature's speed becomes 0, and it can't benefit from any bonus to its speed."
            },
            new Condition
            {
                Name = "Incapacitated",
                Description = "An incapacitated creature can't take actions or reactions."
            },
            new Condition
            {
                Name = "Invisible",
                Description = "An invisible creature is impossible to see without the aid of magic or a special sense."
            },
            new Condition
            {
                Name = "Paralyzed",
                Description = "A paralyzed creature is incapacitated and can't move or speak."
            },
            new Condition
            {
                Name = "Petrified",
                Description = "A petrified creature is transformed, along with any nonmagical object it is wearing or carrying, into a solid inanimate substance."
            },
            new Condition
            {
                Name = "Poisoned",
                Description = "A poisoned creature has disadvantage on attack rolls and ability checks."
            },
            new Condition
            {
                Name = "Prone",
                Description = "A prone creature's only movement option is to crawl, unless it stands up and thereby ends the condition."
            },
            new Condition
            {
                Name = "Restrained",
                Description = "A restrained creature's speed becomes 0, and it can't benefit from any bonus to its speed."
            },
            new Condition
            {
                Name = "Stunned",
                Description = "A stunned creature is incapacitated and can't move or speak."
            },
            new Condition
            {
                Name = "Unconscious",
                Description = "An unconscious creature is incapacitated and can't move or speak."
            }
        };
        context.Conditions.AddRange(conditions);
        context.SaveChanges();

        return conditions;
    }
}
