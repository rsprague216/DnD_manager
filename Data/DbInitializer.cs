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

        // ********************************************* SEEDING CLASS FEATURES DATA  *********************************************
        var ClassFeatures = new ClassFeature[]
        {
            // Barbarian Class Features
            new ClassFeature
            {
                Name = "Rage",
                Description = "You can enter a rage as a bonus action, gaining advantage on Strength checks and saving throws, and dealing extra damage with melee weapon attacks.",
                FeatureLevel = 1,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Unarmored Defense",
                Description = "While not wearing armor, your Armor Class equals 10 + your Dexterity modifier + your Constitution modifier.",
                FeatureLevel = 1,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Weapon Mastery",
                Description = "You gain proficiency with all simple and martial weapons.",
                FeatureLevel = 1,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Danger Sense",
                Description = "You have advantage on Dexterity saving throws against effects that you can see, such as traps and spells.",
                FeatureLevel = 2,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Reckless Attack",
                Description = "You can choose to attack recklessly, gaining advantage on melee weapon attack rolls using Strength during your turn.",
                FeatureLevel = 2,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 3rd level, you choose a subclass that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Primal Knowledge",
                Description = "You gain proficiency in one skill of your choice from the barbarian skill list.",
                FeatureLevel = 3,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Extra Attack",
                Description = "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                FeatureLevel = 5,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Fast Movement",
                Description = "Your speed increases by 10 feet while you are not wearing heavy armor.",
                FeatureLevel = 5,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 6th level, you gain an additional feature from your subclass.",
                FeatureLevel = 6,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Feral Instinct",
                Description = "You have advantage on initiative rolls, and if you are surprised at the beginning of combat and aren't incapacitated, you can act normally on your first turn.",
                FeatureLevel = 7,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Instinctive Pounce",
                Description = "When you use the Dash action, difficult terrain doesn't cost you extra movement on that turn.",
                FeatureLevel = 7,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Brutal Strike",
                Description = "When you score a critical hit with a melee weapon attack, you can roll one additional weapon damage die when determining the extra damage.",
                FeatureLevel = 9,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 10th level, you gain an additional feature from your subclass.",
                FeatureLevel = 10,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Relentless Rage",
                Description = "If you drop to 0 hit points while raging and don't die outright, you can make a DC 10 Constitution saving throw to remain at 1 hit point.",
                FeatureLevel = 11,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Improved Brutal Strike",
                Description = "When you score a critical hit with a melee weapon attack, you can roll two additional weapon damage dice when determining the extra damage.",
                FeatureLevel = 13,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 14th level, you gain an additional feature from your subclass.",
                FeatureLevel = 14,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Persistent Rage",
                Description = "Your rage lasts until you are incapacitated or you choose to end it, rather than ending early if you don't attack a hostile creature or take damage.",
                FeatureLevel = 15,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Improved Brutal Strike",
                Description = "When you score a critical hit with a melee weapon attack, you can roll three additional weapon damage dice when determining the extra damage.",
                FeatureLevel = 17,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Indomitable Might",
                Description = "If your total for a Strength check is less than your Strength score, you can use that score in place of the total.",
                FeatureLevel = 18,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[0].Id // Barbarian
            },
            new ClassFeature
            {
                Name = "Primal Champion",
                Description = "Your Strength and Constitution scores increase by 4, and your maximum for those scores is now 24.",
                FeatureLevel = 20,
                ClassId = classes[0].Id // Barbarian
            },


            // Bard Class Features
            new ClassFeature
            {
                Name = "Bardic Inspiration",
                Description = "You can inspire others through stirring words or music, granting them a bonus to ability checks, attack rolls, or saving throws.",
                FeatureLevel = 1,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Spellcasting",
                Description = "You can cast bard spells using Charisma as your spellcasting ability.",
                FeatureLevel = 1,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Expertise",
                Description = "At 2nd level, you can choose two skills in which you double your proficiency bonus.",
                FeatureLevel = 2,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Jack of All Trades",
                Description = "At 2nd level, you gain a bonus to any ability check that doesn't already include your proficiency bonus.",
                FeatureLevel = 2,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Bard Subclass",
                Description = "At 3rd level, you choose a bardic college that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Font of Inspiration",
                Description = "At 5th level, you regain all expended uses of Bardic Inspiration when you finish a short or long rest.",
                FeatureLevel = 5,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 6th level, you gain an additional feature from your bardic college.",
                FeatureLevel = 6,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Countercharm",
                Description = "At 7th level, you can use your action to start a performance that lasts until the end of your next turn, granting you and your allies advantage on saving throws against being frightened or charmed.",
                FeatureLevel = 7,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Expertise",
                Description = "At 9th level, you can choose two additional skills in which you double your proficiency bonus.",
                FeatureLevel = 9,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Magical Secrets",
                Description = "At 10th level, you learn two spells from any class's spell list, which count as bard spells for you.",
                FeatureLevel = 10,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 14th level, you gain an additional feature from your bardic college.",
                FeatureLevel = 14,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Superior Inspiration",
                Description = "At 18th level, when you roll initiative and have no uses of Bardic Inspiration left, you regain one use.",
                FeatureLevel = 18,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[1].Id // Bard
            },
            new ClassFeature
            {
                Name = "Words of Creation",
                Description = "At 20th level, you can use your Bardic Inspiration to create magical effects that last longer and have greater power.",
                FeatureLevel = 20,
                ClassId = classes[1].Id // Bard
            },


            // Cleric Class Features
            new ClassFeature
            {
                Name = "Spellcasting",
                Description = "You can cast cleric spells using Wisdom as your spellcasting ability.",
                FeatureLevel = 1,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Divine Order",
                Description = "At 1st level, you choose a divine order that grants you additional features.",
                FeatureLevel = 1,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Channel Divinity",
                Description = "You can use your Channel Divinity to fuel powerful effects, such as Turn Undead or other order-specific abilities.",
                FeatureLevel = 2,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Cleric Subclass",
                Description = "At 3rd level, you choose a cleric subclass that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Sear Undead",
                Description = "At 5th level, you can use your Channel Divinity to deal radiant damage to undead, and force them to flee from you. ",
                FeatureLevel = 5,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 6th level, you gain an additional feature from your cleric subclass.",
                FeatureLevel = 6,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Blessed Strikes",
                Description = "At 7th level, you can add your Wisdom modifier to the damage of your weapon attacks.",
                FeatureLevel = 7,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Divine Intervention",
                Description = "At 10th level, you can call upon your deity for aid, potentially receiving a powerful boon.",
                FeatureLevel = 10,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Improved Blessed Strikes",
                Description = "At 14th level, you can add your Wisdom modifier to the damage of your weapon attacks, and your spells that deal damage.",
                FeatureLevel = 14,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 17th level, you gain an additional feature from your cleric subclass.",
                FeatureLevel = 17,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[2].Id // Cleric
            },
            new ClassFeature
            {
                Name = "Greater Divine Intervention",
                Description = "At 20th level, your calls for divine intervention are more likely to succeed, and you can use it more frequently.",
                FeatureLevel = 20,
                ClassId = classes[2].Id // Cleric
            },


            // Druid Class Features
            new ClassFeature
            {
                Name = "Spellcasting",
                Description = "You can cast druid spells using Wisdom as your spellcasting ability.",
                FeatureLevel = 1,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Druidic",
                Description = "You know the secret language of druids, which allows you to communicate with other druids and understand their signs and symbols.",
                FeatureLevel = 1,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Primal Order",
                Description = "At 1st level, you choose a primal order that grants you additional features.",
                FeatureLevel = 1,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Wild Shape",
                Description = "You can use your action to magically assume the shape of a beast you have seen before, gaining its physical abilities.",
                FeatureLevel = 2,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Wild Companion",
                Description = "At 2nd level, you can summon a beast companion to aid you in combat and exploration.",
                FeatureLevel = 2,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Druid Subclass",
                Description = "At 3rd level, you choose a druid subclass that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Wild Resurgence",
                Description = "At 5th level, you can use your Wild Shape to regain hit points equal to your druid level.",
                FeatureLevel = 5,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 6th level, you gain an additional feature from your druid subclass.",
                FeatureLevel = 6,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Elemental Fury",
                Description = "At 7th level, you can channel the power of the elements to enhance your spells, dealing additional damage based on the element you choose.",
                FeatureLevel = 7,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 10th level, you gain an additional feature from your druid subclass.",
                FeatureLevel = 10,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Sublcass Feature",
                Description = "At 14th level, you gain an additional feature from your druid subclass.",
                FeatureLevel = 14,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Improved Elemental Fury",
                Description = "At 15th level, you can choose two elements to enhance your spells, dealing additional damage based on both elements.",
                FeatureLevel = 15,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Beast Spells",
                Description = "At 18th level, you can cast druid spells while in your Wild Shape form, allowing you to maintain your magical abilities even in beast form.",
                FeatureLevel = 18,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[3].Id // Druid
            },
            new ClassFeature
            {
                Name = "Archdruid",
                Description = "At 20th level, you can use your Wild Shape an unlimited number of times, and you can ignore the verbal and somatic components of your druid spells, as long as you are not incapacitated.",
                FeatureLevel = 20,
                ClassId = classes[3].Id // Druid
            },


            // Fighter Class Features
            new ClassFeature
            {
                Name = "Fighting Style",
                Description = "At 1st level, you can choose a fighting style that enhances your combat abilities.",
                FeatureLevel = 1,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Second Wind",
                Description = "You can use a bonus action to regain hit points equal to 1d10 + your fighter level once per short or long rest.",
                FeatureLevel = 1,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Weapon Mastery",
                Description = "You gain proficiency with all simple and martial weapons, and you can add your proficiency bonus to damage rolls with those weapons.",
                FeatureLevel = 1,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Action Surge",
                Description = "At 2nd level, you can take one additional action on your turn, which can be used to attack, dash, disengage, or use an object.",
                FeatureLevel = 2,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Tactical Mind",
                Description = "At 2nd level, you can use your action to analyze the battlefield, gaining advantage on your next attack roll or saving throw.",
                FeatureLevel = 2,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Fighter Subclass",
                Description = "At 3rd level, you choose a fighter archetype that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Extra Attack",
                Description = "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                FeatureLevel = 5,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Tactical Shift",
                Description = "At 5th level, you can use your action to reposition yourself on the battlefield, allowing you to move up to half your speed without provoking opportunity attacks.",
                FeatureLevel = 5,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 6th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 6,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 7th level, you gain an additional feature from your fighter archetype.",
                FeatureLevel = 7,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Indomitable",
                Description = "At 9th level, you can reroll a failed saving throw once per long rest.",
                FeatureLevel = 9,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Tactical Master",
                Description = "At 9th level, you can use your action to grant yourself and allies within 30 feet advantage on their next attack roll or saving throw.",
                FeatureLevel = 9,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 10th level, you gain an additional feature from your fighter archetype.",
                FeatureLevel = 10,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Two Extra Attacks",
                Description = "At 11th level, you can attack three times, instead of twice, whenever you take the Attack action on your turn.",
                FeatureLevel = 11,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Indomitable",
                Description = "At 13th level, you can reroll a failed saving throw twice per long rest.",
                FeatureLevel = 13,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Studied Attacks",
                Description = "At 13th level, you can use your action to study a creature, gaining advantage on your next attack roll against it.",
                FeatureLevel = 13,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 14th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 14,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 15th level, you gain an additional feature from your fighter archetype.",
                FeatureLevel = 15,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Action Surge",
                Description = "At 17th level, you can take one additional action on your turn, which can be used to attack, dash, disengage, or use an object.",
                FeatureLevel = 17,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Indomitable",
                Description = "At 17th level, you can reroll a failed saving throw three times per long rest.",
                FeatureLevel = 17,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 18th level, you gain an additional feature from your fighter archetype.",
                FeatureLevel = 18,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[4].Id // Fighter
            },
            new ClassFeature
            {
                Name = "Three Extra Attacks",
                Description = "At 20th level, you can attack four times, instead of three, whenever you take the Attack action on your turn.",
                FeatureLevel = 20,
                ClassId = classes[4].Id // Fighter
            },


            // Monk Class Features
            new ClassFeature
            {
                Name = "Martial Arts",
                Description = "You can use Dexterity instead of Strength for the attack and damage rolls of your unarmed strikes and monk weapons.",
                FeatureLevel = 1,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Unarmored Defense",
                Description = "While not wearing armor, your Armor Class equals 10 + your Dexterity modifier + your Wisdom modifier.",
                FeatureLevel = 1,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Monk's Focus",
                Description = "At 2nd level, you can focus your mind and body, gaining advantage on Wisdom saving throws and initiative rolls.",
                FeatureLevel = 2,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Unarmored Movement",
                Description = "At 2nd level, your speed increases by 10 feet while you are not wearing armor or wielding a shield.",
                FeatureLevel = 2,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Uncanny Metabolism",
                Description = "At 2nd level, you can use your action to regain hit points equal to your monk level once per short or long rest.",
                FeatureLevel = 2,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Deflect Attacks",
                Description = "At 3rd level, you can use your reaction to reduce the damage of an attack that hits you, potentially reducing it to zero.",
                FeatureLevel = 3,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Monk Subclass",
                Description = "At 3rd level, you choose a monastic tradition that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Slow Fall",
                Description = "At 4th level, you can use your reaction to reduce falling damage by an amount equal to five times your monk level.",
                FeatureLevel = 4,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Extra Attack",
                Description = "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                FeatureLevel = 5,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Stunning Strike",
                Description = "At 5th level, you can use your ki to attempt to stun a creature you hit with a melee weapon attack, potentially rendering it incapacitated.",
                FeatureLevel = 5,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Empowered Strikes",
                Description = "At 6th level, your unarmed strikes count as magical for overcoming resistance and immunity to nonmagical attacks and damage.",
                FeatureLevel = 6,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 6th level, you gain an additional feature from your monastic tradition.",
                FeatureLevel = 6,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Evasion",
                Description = "At 7th level, you can nimbly dodge out of the way of certain area effects, such as a red dragon's fiery breath or an ice storm spell.",
                FeatureLevel = 7,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Acrobatic Movement",
                Description = "At 9th level, you can use your action to perform acrobatic maneuvers, allowing you to move through difficult terrain without penalty.",
                FeatureLevel = 9,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Heightened Focus",
                Description = "At 10th level, you can use your action to focus your mind, gaining advantage on Wisdom saving throws and initiative rolls until the end of your next turn.",
                FeatureLevel = 10,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Self-Restoration",
                Description = "At 10th level, you can use your action to regain hit points equal to your monk level once per long rest.",
                FeatureLevel = 10,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 11th level, you gain an additional feature from your monastic tradition.",
                FeatureLevel = 11,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Deflect Energy",
                Description = "At 13th level, you can use your reaction to reduce the damage of an energy-based attack that hits you, potentially reducing it to zero.",
                FeatureLevel = 13,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Disciplined Survivor",
                Description = "At 14th level, you can use your action to enter a state of heightened awareness, gaining advantage on all saving throws until the end of your next turn.",
                FeatureLevel = 14,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Perfect Focus",
                Description = "At 15th level, you can use your action to enter a state of perfect focus, allowing you to ignore the effects of exhaustion and gain advantage on all ability checks until the end of your next turn.",
                FeatureLevel = 15,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 17th level, you gain an additional feature from your monastic tradition.",
                FeatureLevel = 17,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Superior Defense",
                Description = "At 18th level, you can use your reaction to gain resistance to all damage types until the start of your next turn.",
                FeatureLevel = 18,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[5].Id // Monk
            },
            new ClassFeature
            {
                Name = "Body and Mind",
                Description = "At 20th level, you can use your action to enter a state of perfect harmony, allowing you to regain all expended ki points and gain advantage on all attack rolls and saving throws until the end of your next turn.",
                FeatureLevel = 20,
                ClassId = classes[5].Id // Monk
            },


            // Paladin Class Features
            new ClassFeature
            {
                Name = "Lay on Hands",
                Description = "You can use your action to heal a creature you touch, restoring a number of hit points equal to your paladin level times 5.",
                FeatureLevel = 1,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Spellcasting",
                Description = "You can cast paladin spells using Charisma as your spellcasting ability.",
                FeatureLevel = 1,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Weapon Mastery",
                Description = "You gain proficiency with all simple and martial weapons, and you can add your proficiency bonus to damage rolls with those weapons.",
                FeatureLevel = 1,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Fighting Style",
                Description = "At 2nd level, you can choose a fighting style that enhances your combat abilities.",
                FeatureLevel = 2,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Paladin's Smite",
                Description = "At 2nd level, you can use your action to channel divine energy into your weapon attacks, dealing additional radiant damage.",
                FeatureLevel = 2,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Channel Divinity",
                Description = "At 3rd level, you can use your Channel Divinity to fuel powerful effects, such as Turn Undead or other paladin-specific abilities.",
                FeatureLevel = 3,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Paladin Subclass",
                Description = "At 3rd level, you choose a paladin subclass that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Extra Attack",
                Description = "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                FeatureLevel = 5,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Faithful Steed",
                Description = "At 5th level, you can summon a celestial steed to aid you in combat and exploration.",
                FeatureLevel = 5,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Aura of Protection",
                Description = "At 6th level, you and friendly creatures within 10 feet of you gain a bonus to saving throws equal to your Charisma modifier.",
                FeatureLevel = 6,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 7th level, you gain an additional feature from your paladin subclass.",
                FeatureLevel = 7,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Abjure Foes",
                Description = "At 9th level, you can use your Channel Divinity to force enemies within 30 feet to make a Wisdom saving throw or be frightened for 1 minute.",
                FeatureLevel = 9,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Aura of Courage",
                Description = "At 10th level, you and friendly creatures within 10 feet of you can't be frightened while you are conscious.",
                FeatureLevel = 10,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Radiant Strikes",
                Description = "At 11th level, your weapon attacks deal additional radiant damage equal to your Charisma modifier.",
                FeatureLevel = 11,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Restoring Touch",
                Description = "At 14th level, you can use your Lay on Hands feature to remove a condition affecting a creature, such as blinded, charmed, or frightened.",
                FeatureLevel = 14,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 15th level, you gain an additional feature from your paladin subclass.",
                FeatureLevel = 15,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Aura Expansion",
                Description = "At 18th level, the range of your Aura of Protection and Aura of Courage increases to 30 feet.",
                FeatureLevel = 18,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[6].Id // Paladin
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 20th level, you gain an additional feature from your paladin subclass.",
                FeatureLevel = 20,
                ClassId = classes[6].Id // Paladin
            },


            // Ranger Class Features
            new ClassFeature
            {
                Name = "Spellcasting",
                Description = "You can cast ranger spells using Wisdom as your spellcasting ability.",
                FeatureLevel = 1,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Favored Enemy",
                Description = "At 1st level, you choose a type of creature as your favored enemy, gaining bonuses to damage and tracking against them.",
                FeatureLevel = 1,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Weapon Mastery",
                Description = "You gain proficiency with all simple and martial weapons, and you can add your proficiency bonus to damage rolls with those weapons.",
                FeatureLevel = 1,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Deft Explorer",
                Description = "At 1st level, you gain proficiency in one skill of your choice, and you can add double your proficiency bonus to checks with that skill.",
                FeatureLevel = 1,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Fighting Style",
                Description = "At 2nd level, you can choose a fighting style that enhances your combat abilities.",
                FeatureLevel = 2,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Ranger Subclass",
                Description = "At 3rd level, you choose a ranger archetype that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Extra Attack",
                Description = "Beginning at 5th level, you can attack twice, instead of once, whenever you take the Attack action on your turn.",
                FeatureLevel = 5,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Roving",
                Description = "At 6th level, your walking speed increases by 5 feet, and you can move through difficult terrain without expending extra movement.",
                FeatureLevel = 6,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 7th level, you gain an additional feature from your ranger archetype.",
                FeatureLevel = 7,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Expertise",
                Description = "At 9th level, you can choose two skills in which you have proficiency, and double your proficiency bonus for checks with those skills.",
                FeatureLevel = 9,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Tireless",
                Description = "At 10th level, you can use your action to gain temporary hit points equal to your ranger level, and you can't be exhausted while you have these temporary hit points.",
                FeatureLevel = 10,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 11th level, you gain an additional feature from your ranger archetype.",
                FeatureLevel = 11,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Relentless Hunter",
                Description = "At 13th level, you can use your action to track a creature you can see within 60 feet of you, gaining advantage on Wisdom (Survival) checks to track it for the next hour.",
                FeatureLevel = 13,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Nature's Veil",
                Description = "At 14th level, you can use your action to become invisible until the end of your next turn, as long as you are in natural terrain.",
                FeatureLevel = 14,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 15th level, you gain an additional feature from your ranger archetype.",
                FeatureLevel = 15,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Precise Hunter",
                Description = "At 17th level, you can use your action to gain advantage on all attack rolls against a creature you can see within 60 feet of you until the end of your next turn.",
                FeatureLevel = 17,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Feral Senses",
                Description = "At 18th level, you can use your action to gain blindsight out to a range of 30 feet for 1 minute, allowing you to see invisible creatures and objects.",
                FeatureLevel = 18,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[7].Id // Ranger
            },
            new ClassFeature
            {
                Name = "Foe Slayer",
                Description = "At 20th level, you can use your action to designate a creature you can see within 60 feet of you as your foe, gaining advantage on all attack rolls against it until the end of your next turn.",
                FeatureLevel = 20,
                ClassId = classes[7].Id // Ranger
            },


            // Rogue Class Features
            new ClassFeature
            {
                Name = "Expertise",
                Description = "At 1st level, you can choose two skills in which you have proficiency, and double your proficiency bonus for checks with those skills.",
                FeatureLevel = 1,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Sneak Attack",
                Description = "At 1st level, you can deal extra damage when you hit a creature with a finesse or ranged weapon attack, provided you have advantage on the attack roll or an ally is within 5 feet of the target.",
                FeatureLevel = 1,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Thieves' Cant",
                Description = "You learn a secret language known only to rogues, allowing you to communicate in code with other rogues.",
                FeatureLevel = 1,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Weapon Mastery",
                Description = "You gain proficiency with all simple and martial weapons, and you can add your proficiency bonus to damage rolls with those weapons.",
                FeatureLevel = 1,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Cunning Action",
                Description = "At 2nd level, you can use your bonus action to take the Dash, Disengage, or Hide action.",
                FeatureLevel = 2,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Rogue Subclass",
                Description = "At 3rd level, you choose a rogue archetype that grants you additional features.",
                FeatureLevel = 3,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Steady Aim",
                Description = "At 3rd level, you can use your bonus action to gain advantage on your next attack roll against a creature within 30 feet of you, provided you haven't moved this turn.",
                FeatureLevel = 3,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 4th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 4,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Cunning Strike",
                Description = "At 5th level, you can use your action to make a melee weapon attack against a creature, dealing additional damage equal to your rogue level.",
                FeatureLevel = 5,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Uncanny Dodge",
                Description = "At 5th level, you can use your reaction to halve the damage of an attack that hits you, provided you can see the attacker.",
                FeatureLevel = 5,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Expertise",
                Description = "At 6th level, you can choose two additional skills in which you have proficiency, and double your proficiency bonus for checks with those skills.",
                FeatureLevel = 6,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Evasion",
                Description = "At 7th level, you can nimbly dodge out of the way of certain area effects, such as a red dragon's fiery breath or an ice storm spell.",
                FeatureLevel = 7,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Reliable Talent",
                Description = "At 7th level, whenever you make an ability check that lets you add your proficiency bonus, you can treat a d20 roll of 9 or lower as a 10.",
                FeatureLevel = 7,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 8th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 8,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 9th level, you gain an additional feature from your rogue archetype.",
                FeatureLevel = 9,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 10th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 10,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Improved Cunning Strike",
                Description = "At 11th level, your Cunning Strike deals additional damage equal to your rogue level.",
                FeatureLevel = 11,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 12th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 12,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 13th level, you gain an additional feature from your rogue archetype.",
                FeatureLevel = 13,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Devious Strikes",
                Description = "At 14th level, you can use your action to make a melee weapon attack against a creature, dealing additional damage equal to your rogue level.",
                FeatureLevel = 14,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Slippery Mind",
                Description = "At 15th level, you gain proficiency in Wisdom saving throws, and you can add your proficiency bonus to Wisdom saving throws.",
                FeatureLevel = 15,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Ability Score Improvement",
                Description = "At 16th level, you can increase one ability score of your choice by 2, or two ability scores by 1 each, or take a feat.",
                FeatureLevel = 16,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Subclass Feature",
                Description = "At 17th level, you gain an additional feature from your rogue archetype.",
                FeatureLevel = 17,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Elusive",
                Description = "At 18th level, you can use your action to become invisible until the end of your next turn, allowing you to move through enemies without provoking opportunity attacks.",
                FeatureLevel = 18,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Epic Boon",
                Description = "At 19th level, you gain an epic boon that grants you a powerful ability.",
                FeatureLevel = 19,
                ClassId = classes[8].Id // Rogue
            },
            new ClassFeature
            {
                Name = "Stroke of Luck",
                Description = "At 20th level, you can use your action to turn a failed attack roll or ability check into a success, provided you can see the target.",
                FeatureLevel = 20,
                ClassId = classes[8].Id // Rogue
            }


            // Sorcerer Class Features

            // Warlock Class Features

            // Wizard Class Features

            // Artificer Class Features
        };
        context.ClassFeatures.AddRange(ClassFeatures);
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

        // ********************************************* SEEDING SKILL DATA *********************************************
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