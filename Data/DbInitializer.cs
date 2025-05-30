using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static class DbInitializer
{
    public static void Initialize(CharacterContext context)
    {
        context.Database.EnsureDeleted();  // Drop the database if it exists
        context.Database.EnsureCreated();  // Create the database if it doesn't exist

        if (context.Characters.Any()) { return; } // DB has been seeded

        // ********************************************* SEEDING RACE DATA  *********************************************
            var races = new Race[]
        {
            new Race
            {   // 0
                Name = "Human",
                Size = "Medium",
                Speed = 30,
                MaxAge = 80,
                Languages = new List<string> { "Common", "Any one language" },
                // Traits = new List<string> { "Ability Score Increase: +1 to all ability scores" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 1
                Name = "Elf",
                Size = "Medium",
                Speed = 30,
                MaxAge = 750,
                Languages = new List<string> { "Common", "Elvish" },
                // Traits = new List<string> { "Ability Score Increase: +2 Dexterity", "Darkvision", "Fey Ancestry", "Trance" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 2
                Name = "Aasimar",
                Size = "Medium",
                Speed = 30,
                MaxAge = 160,
                Languages = new List<string> { "Common", "Celestial" },
                // Traits = new List<string> { "Ability Score Increase: +2 Charisma", "Darkvision", "Celestial Resistance", "Healing Hands" },
                Source = "Volo's Guide to Monsters"
            },
            new Race
            {   // 3
                Name = "Tiefling",
                Size = "Medium",
                Speed = 30,
                MaxAge = 120,
                Languages = new List<string> { "Common", "Infernal" },
                // Traits = new List<string> { "Ability Score Increase: +2 Charisma", "Darkvision", "Hellish Resistance", "Infernal Legacy" },
                Source = "Player's Handbook"
            },
            new Race
            {   // 4
                Name = "Half-Elf",
                Size = "Medium",
                Speed = 30,
                MaxAge = 180,
                Languages = new List<string> { "Common", "Elvish" },
                // Traits = new List<string> { "Ability Score Increase: +2 Charisma, +1 to two other ability scores", "Fey Ancestry", "Skill Versatility" },
                Source = "Player's Handbook"
            }
        };
        context.Races.AddRange(races);
        context.SaveChanges();

        // ********************************************* SEEDING SUBRACE DATA  *********************************************
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

        // ********************************************* SEEDING CLASS DATA  *********************************************
        var classes = new Class[]
        {
            new Class
            {   // 0
                Name = "Barbarian",
                HitDie = 12,
                SavingThrows = new List<string> { "Strength", "Constitution" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 1
                Name = "Bard",
                HitDie = 8,
                SavingThrows = new List<string> { "Dexterity", "Charisma" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 2
                Name = "Cleric",
                HitDie = 8,
                SavingThrows = new List<string> { "Wisdom", "Charisma" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 3
                Name = "Druid",
                HitDie = 8,
                SavingThrows = new List<string> { "Intelligence", "Wisdom" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 4
                Name = "Fighter",
                HitDie = 10,
                SavingThrows = new List<string> { "Strength", "Constitution" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 5
                Name = "Monk",
                HitDie = 8,
                SavingThrows = new List<string> { "Strength", "Dexterity" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 6
                Name = "Paladin",
                HitDie = 10,
                SavingThrows = new List<string> { "Strength", "Charisma" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 7
                Name = "Ranger",
                HitDie = 10,
                SavingThrows = new List<string> { "Strength", "Dexterity" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 8
                Name = "Rogue",
                HitDie = 8,
                SavingThrows = new List<string> { "Dexterity", "Intelligence" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 9
                Name = "Sorcerer",
                HitDie = 6,
                SavingThrows = new List<string> { "Constitution", "Charisma" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 10
                Name = "Warlock",
                HitDie = 8,
                SavingThrows = new List<string> { "Wisdom", "Charisma" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 11
                Name = "Wizard",
                HitDie = 6,
                SavingThrows = new List<string> { "Intelligence", "Wisdom" },
                Source = "Player's Handbook"
            },
            new Class
            {   // 12
                Name = "Artificer",
                HitDie = 8,
                SavingThrows = new List<string> { "Constitution", "Intelligence" },
                Source = "Eberron: Rising from the Last War"
            },
            new Class
            {   // 13
                Name = "Blood Hunter",
                HitDie = 10,
                SavingThrows = new List<string> { "Strength", "Intelligence" },
                Source = "Critical Role"
            }
        };
        context.Classes.AddRange(classes);
        context.SaveChanges();

        // ********************************************* SEEDING STATS DATA  *********************************************
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

        // ********************************************* SEEDING SKILL DATA  *********************************************
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

        // ********************************************* SEEDING CONDITIONS DATA  *********************************************
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

        // ********************************************* SEEDING CHARACTER DATA  *********************************************
        var characters = new Character[]
        {
            new Character
            {
                Name = "Lilowyn Shayemar",
                RaceId = races[2].Id,
                SubraceId = null,
                HitPoints = 91,
                CurrentHitPoints = 76,
                Level = 8
            },
            new Character
            {
                Name = "Lilith Wavestrider",
                RaceId = races[0].Id,
                SubraceId = 3,
                HitPoints = 24,
                CurrentHitPoints = 13,
                Level = 3
            },
            new Character
            {
                Name = "Hendrik",
                RaceId = races[0].Id,
                SubraceId = 3,
                HitPoints = 39,
                CurrentHitPoints = 24,
                Level = 4
            },
            new Character
            {
                Name = "Baziros",
                RaceId = races[3].Id,
                SubraceId = null,
                HitPoints = 60,
                CurrentHitPoints = 32,
                Level = 7
            },
            new Character
            {
                Name = "Sir Reginald Archibald Maximilian Percival Thaddeus Montgomery the Third, Keeper of the Sacred Amulet of Everlasting Light and Defender of the Seven Realms",
                RaceId = races[4].Id,
                SubraceId = null,
                HitPoints = 110,
                CurrentHitPoints = 110,
                Level = 10
            }
        };
        context.Characters.AddRange(characters);
        context.SaveChanges();

        // ********************************************* SEEDING CHARACTER STATS DATA  *********************************************
        var characterStats = new CharacterStat[]
        {
            // Lilowyn Shayemar
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[0].Id, Value = 8 },
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[1].Id, Value = 11 },
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[2].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[3].Id, Value = 14 },
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[4].Id, Value = 18 },
            new CharacterStat { CharacterId = characters[0].Id, StatId = stats[5].Id, Value = 16 },
            // Lilith Wavestrider
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[0].Id, Value = 14 },
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[1].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[2].Id, Value = 10 },
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[3].Id, Value = 9 },
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[4].Id, Value = 13 },
            new CharacterStat { CharacterId = characters[1].Id, StatId = stats[5].Id, Value = 16 },
            // Hendrik
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[0].Id, Value = 14 },
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[1].Id, Value = 19 },
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[2].Id, Value = 18 },
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[3].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[4].Id, Value = 12 },
            new CharacterStat { CharacterId = characters[2].Id, StatId = stats[5].Id, Value = 11 },
            // Baziros
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[0].Id, Value = 14 },
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[1].Id, Value = 18 },
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[2].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[3].Id, Value = 9 },
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[4].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[3].Id, StatId = stats[5].Id, Value = 13 },
            // Sir Reginald
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[0].Id, Value = 18 },
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[1].Id, Value = 12 },
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[2].Id, Value = 16 },
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[3].Id, Value = 14 },
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[4].Id, Value = 15 },
            new CharacterStat { CharacterId = characters[4].Id, StatId = stats[5].Id, Value = 20 }
        };
        context.CharacterStats.AddRange(characterStats);
        context.SaveChanges();

        // ********************************************* SEEDING CHARACTER SKILLS DATA  *********************************************
        var characterSkills = new CharacterSkill[]
        {
            // Lilowyn Shayemar
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[0].Id, Proficiency = 1 }, // Acrobatics
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[1].Id, Proficiency = 0 }, // Animal Handling
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[2].Id, Proficiency = 2 }, // Arcana
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[3].Id, Proficiency = 0 }, // Athletics
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[4].Id, Proficiency = 1 }, // Deception
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[5].Id, Proficiency = 0 }, // History
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[6].Id, Proficiency = 1 }, // Insight
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[7].Id, Proficiency = 0 }, // Intimidation
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[8].Id, Proficiency = 1 }, // Investigation
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[9].Id, Proficiency = 0 }, // Medicine
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[10].Id, Proficiency = 0 }, // Nature
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[11].Id, Proficiency = 2 }, // Perception
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[12].Id, Proficiency = 0 }, // Performance
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[13].Id, Proficiency = 1 }, // Persuasion
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[14].Id, Proficiency = 0 }, // Religion
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[15].Id, Proficiency = 0 }, // Sleight of Hand
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[16].Id, Proficiency = 1 }, // Stealth
            new CharacterSkill { CharacterId = characters[0].Id, SkillId = skills[17].Id, Proficiency = 0 }, // Survival
            // Lilith Wavestrider
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[0].Id, Proficiency = 0 }, // Acrobatics
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[1].Id, Proficiency = 1 }, // Animal Handling
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[2].Id, Proficiency = 0 }, // Arcana
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[3].Id, Proficiency = 0 }, // Athletics
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[4].Id, Proficiency = 1 }, // Deception
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[5].Id, Proficiency = 0 }, // History
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[6].Id, Proficiency = 0 }, // Insight
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[7].Id, Proficiency = 0 }, // Intimidation
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[8].Id, Proficiency = 0 }, // Investigation
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[9].Id, Proficiency = 0 }, // Medicine
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[10].Id, Proficiency = 0 }, // Nature
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[11].Id, Proficiency = 2 }, // Perception
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[12].Id, Proficiency = 0 }, // Performance
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[13].Id, Proficiency = 1 }, // Persuasion
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[14].Id, Proficiency = 0 }, // Religion
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[15].Id, Proficiency = 0 }, // Sleight of Hand
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[16].Id, Proficiency = 1 }, // Stealth
            new CharacterSkill { CharacterId = characters[1].Id, SkillId = skills[17].Id, Proficiency = 0 }, // Survival
            // Hendrik
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[0].Id, Proficiency = 0 }, // Acrobatics
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[1].Id, Proficiency = 0 }, // Animal Handling
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[2].Id, Proficiency = 0 }, // Arcana
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[3].Id, Proficiency = 1 }, // Athletics
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[4].Id, Proficiency = 0 }, // Deception
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[5].Id, Proficiency = 0 }, // History
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[6].Id, Proficiency = 1 }, // Insight
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[7].Id, Proficiency = 0 }, // Intimidation
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[8].Id, Proficiency = 0 }, // Investigation
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[9].Id, Proficiency = 0 }, // Medicine
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[10].Id, Proficiency = 0 }, // Nature
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[11].Id, Proficiency = 1 }, // Perception
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[12].Id, Proficiency = 0 }, // Performance
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[13].Id, Proficiency = 1 }, // Persuasion
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[14].Id, Proficiency = 0 }, // Religion
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[15].Id, Proficiency = 0 }, // Sleight of Hand
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[16].Id, Proficiency = 1 }, // Stealth
            new CharacterSkill { CharacterId = characters[2].Id, SkillId = skills[17].Id, Proficiency = 0 }, // Survival
            // Baziros
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[0].Id, Proficiency = 0 }, // Acrobatics
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[1].Id, Proficiency = 0 }, // Animal Handling
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[2].Id, Proficiency = 0 }, // Arcana
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[3].Id, Proficiency = 1 }, // Athletics
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[4].Id, Proficiency = 0 }, // Deception
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[5].Id, Proficiency = 0 }, // History
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[6].Id, Proficiency = 1 }, // Insight
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[7].Id, Proficiency = 0 }, // Intimidation
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[8].Id, Proficiency = 0 }, // Investigation
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[9].Id, Proficiency = 0 }, // Medicine
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[10].Id, Proficiency = 0 }, // Nature
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[11].Id, Proficiency = 1 }, // Perception
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[12].Id, Proficiency = 0 }, // Performance
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[13].Id, Proficiency = 1 }, // Persuasion
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[14].Id, Proficiency = 0 }, // Religion
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[15].Id, Proficiency = 0 }, // Sleight of Hand
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[16].Id, Proficiency = 1 }, // Stealth
            new CharacterSkill { CharacterId = characters[3].Id, SkillId = skills[17].Id, Proficiency = 0 }, // Survival
            // Sir Reginald
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[0].Id, Proficiency = 1 }, // Acrobatics
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[1].Id, Proficiency = 0 }, // Animal Handling
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[2].Id, Proficiency = 0 }, // Arcana
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[3].Id, Proficiency = 1 }, // Athletics
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[4].Id, Proficiency = 1 }, // Deception
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[5].Id, Proficiency = 0 }, // History
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[6].Id, Proficiency = 1 }, // Insight
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[7].Id, Proficiency = 0 }, // Intimidation
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[8].Id, Proficiency = 0 }, // Investigation
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[9].Id, Proficiency = 0 }, // Medicine
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[10].Id, Proficiency = 0 }, // Nature
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[11].Id, Proficiency = 1 }, // Perception
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[12].Id, Proficiency = 0 }, // Performance
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[13].Id, Proficiency = 1 }, // Persuasion
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[14].Id, Proficiency = 0 }, // Religion
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[15].Id, Proficiency = 0 }, // Sleight of Hand
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[16].Id, Proficiency = 1 }, // Stealth
            new CharacterSkill { CharacterId = characters[4].Id, SkillId = skills[17].Id, Proficiency = 0 }  // Survival
        };
        context.CharacterSkills.AddRange(characterSkills);
        context.SaveChanges();

        // ********************************************* SEEDING CHARACTER CLASS DATA  *********************************************
        var characterClasses = new CharacterClass[]
        {
            // Lilowyn Shayemar
            new CharacterClass { CharacterId = characters[0].Id, ClassId = classes[3].Id, Level = 8 },
            // Lilith Wavestrider
            new CharacterClass { CharacterId = characters[1].Id, ClassId = classes[8].Id, Level = 3 },
            // Hendrik
            new CharacterClass { CharacterId = characters[2].Id, ClassId = classes[4].Id, Level = 4 },
            // Baziros
            new CharacterClass { CharacterId = characters[3].Id, ClassId = classes[5].Id, Level = 5, UsedHitDice = 2 },
            new CharacterClass { CharacterId = characters[3].Id, ClassId = classes[2].Id, Level = 2, UsedHitDice = 1 },
            // Sir Reginald
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[6].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[9].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[11].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[10].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[1].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[7].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[3].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[2].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[12].Id, Level = 1 },
            new CharacterClass { CharacterId = characters[4].Id, ClassId = classes[13].Id, Level = 1 }
        };
        context.CharacterClasses.AddRange(characterClasses);
        context.SaveChanges();

        // ********************************************* SEEDING CHARACTER CONDITIONS DATA  *********************************************
        var characterConditions = new CharacterCondition[]
        {
            // Lilowyn Shayemar
            new CharacterCondition { CharacterId = characters[0].Id, ConditionId = conditions[9].Id },
            // Lilith Wavestrider
            new CharacterCondition { CharacterId = characters[1].Id, ConditionId = conditions[9].Id },
            // Hendrik
            new CharacterCondition { CharacterId = characters[2].Id, ConditionId = conditions[9].Id },
            // Baziros
            // new CharacterCondition { CharacterId = characters[3].Id, ConditionId = conditions[9].Id },
            // Sir Reginald
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[0].Id },
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[1].Id },
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[2].Id },
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[3].Id },
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[4].Id },
            new CharacterCondition { CharacterId = characters[4].Id, ConditionId = conditions[5].Id }
        };
        context.CharacterConditions.AddRange(characterConditions);
        context.SaveChanges();

    }
}