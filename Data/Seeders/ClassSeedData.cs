using DnD_Manager.Models;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    private static Class[] SeedClasses(CharacterContext context)
    {
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

        return classes;
    }

    private static void SeedClassFeatures(CharacterContext context, Class[] classes)
    {
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
    }
}
