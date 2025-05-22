using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using DnD_Manager.Data;
using DnD_Manager.Models;
using MongoDB.Bson;
using Microsoft.EntityFrameworkCore;

namespace DnD_Manager.Pages.PlayerCharacters;

public class CharacterModel : PageModel
{
    private readonly CharacterContext _context;

    public CharacterModel(CharacterContext context)
    {
        _context = context;
    }

    public Character Character { get; set; } = default!;
    public List<Condition> AllConditions { get; set; } = new();


    // TEMPORARY LISTS *****************
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
    // TEMPORARY LISTS *****************

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null) { return NotFound(); }

        var character = await _context.Characters
            .Include(character => character.Race)
            .Include(character => character.Subrace)
            .Include(character => character.Stats).ThenInclude(charStat => charStat.Stat)
            .Include(character => character.CharacterClasses).ThenInclude(charClass => charClass.Class)
            .Include(character => character.Conditions).ThenInclude(charCondition => charCondition.Condition)
            .FirstOrDefaultAsync(character => character.Id == id);

        if (character == null) { return NotFound(); }

        Character = character;

        AllConditions = await _context.Conditions.ToListAsync();

        return Page();
    }

    
}