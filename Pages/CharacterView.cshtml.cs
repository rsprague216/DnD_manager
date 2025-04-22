using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DnD_Manager.Pages;

public class CharacterViewModel : PageModel
{
    private readonly ILogger<CharacterViewModel> _logger;

    public string Name { get; set; } = "Lilith Wavestrider";
    public string Race { get; set; } = "Variant Human";
    public Dictionary<string,int> Classes { get; set; } = new Dictionary<string,int>
    {
        { "Rogue",    3 },
        { "Sorcerer", 2 },
    };
    public Dictionary<string,int> Stats { get; set; } = new Dictionary<string,int>
    {
        { "Strength",     14 },
        { "Dexterity",    16 },
        { "Constitution", 10 },
        { "Intelligence",  9 },
        { "Wisdom",       13 },
        { "Charisma",     16 },
    };
    public Dictionary<string,string> Skills { get; set; } = new Dictionary<string,string>
    {
        { "Acrobatics",      "Dex" },
        { "Animal Handling", "Wis" },
        { "Arcana",          "Int" },
        { "Athletics",       "Str" },
        { "Deception",       "Cha" },
        { "History",         "Int" },
        { "Insight",         "Wis" },
        { "Intimidation",    "Cha" },
        { "Investigation",   "Int" },
        { "Medicine",        "Wis" },
        { "Nature",          "Int" },
        { "Perception",      "Wis" },
        { "Performance",     "Cha" },
        { "Persuasion",      "Cha" },
        { "Religion",        "Int" },
        { "Sleight of Hand", "Dex" },
        { "Stealth",         "Dex" },
        { "Survival",        "Wis" }
    };
    public Dictionary<string,int> Passives { get; set; } = new Dictionary<string,int>
    {
        { "Perception",    13 },
        { "Investigation",  9 },
        { "Insight",       10 }
    };
    public Dictionary<string,int> Senses { get; set; } = new Dictionary<string,int>
    {
        { "Darkvision", 60 },
        { "Blindsight", 10 }
    };
    public Dictionary<string,bool> Conditions { get; set; } = new Dictionary<string,bool>
    {
        { "Blinded",        true },
        { "Charmed",       false },
        { "Deafened",       true },
        { "Frightened",    false },
        { "Grappled",       true },
        { "Incapacitated", false },
        { "Invisible",     false },
        { "Paralyzed",     false },
        { "Petrified",     false },
        { "Poisoned",      false },
        { "Prone",         false },
        { "Restrained",    false },
        { "Stunned",       false },
        { "Unconscious",   false }
    };
    public List<string> Resistances { get; set; } = new List<string>
    {
        "Acid",
        "Cold",
        "Prone"
    };
    public List<string> Immunities { get; set; } = new List<string>
    {
        "Poison",
        "Fear",
        "Charmed"
    };
    public List<string> Vulnerabilities { get; set; } = new List<string>
    {
        "Fire",
        "Lightning"
    };
    public List<string> Armors { get; set; } = new List<string>
    {
        "Light Armor",
        "Medium Armor",
        "Heavy Armor"
    };
    public List<string> Weapons { get; set; } = new List<string>
    {
        "Simple Weapons",
        "Martial Weapons"
    };
    public List<string> Tools { get; set; } = new List<string>
    {
        "Thieves' Tools",
        "Musical Instruments"
    };
    public List<string> Languages { get; set; } = new List<string>
    {
        "Common",
        "Elvish",
        "Draconic"
    };
    public List<string> Actions { get; set; } = new List<string>
    {
        "Unarmed Strike",
        "Damage",
        "Grapple",
        "Shove"
    };


    public CharacterViewModel(ILogger<CharacterViewModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() {}

    public void OnPost() {}
}
