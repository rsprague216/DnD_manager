using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;
using MongoDB.Bson;
using DnD_Manager.Data;
using DnD_Manager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DnD_Manager.Pages.PlayerCharacters;

public class CharactersModel : PageModel
{
    private readonly CharacterContext _context;

    public CharactersModel(CharacterContext context)
    {
        _context = context;
    }

    public List<Character> Characters { get; set; } = new();

    public string DefaultImageUrl { get; set; } = "https://cdn.pixabay.com/photo/2015/10/05/22/37/blank-profile-picture-973460_1280.png";

    public async Task OnGetAsync()
    {
        Characters = await _context.Characters
            .Include(character => character.Race)
            .Include(character => character.Subrace)
            .Include(character => character.CharacterClasses).ThenInclude(characterClass => characterClass.Class)
            .ToListAsync();
    }

    public async Task<IActionResult> OnPostCopyAsync(int? id)
    {
        Console.WriteLine("copying");
        if (id == null) { return NotFound(); }

        var character = await _context.Characters
            .Include(character => character.Race)
            .Include(character => character.Subrace)
            .Include(character => character.Stats)
            .Include(character => character.CharacterClasses)
            .Include(character => character.Conditions)
            .FirstOrDefaultAsync(character => character.Id == id);
        
        if (character == null) { return NotFound(); }

        var newCharacter = new Character
        {
            Name = character.Name + " (Copy)",
            RaceId = character.RaceId,
            SubraceId = character.SubraceId,
            HitPoints = character.HitPoints,
            CurrentHitPoints = character.CurrentHitPoints,
            Stats = character.Stats.Select(charStat => new CharacterStat { StatId = charStat.StatId, Value = charStat.Value }).ToList(),
            CharacterClasses = character.CharacterClasses.Select(characterClass => new CharacterClass { ClassId = characterClass.ClassId, Level = characterClass.Level }).ToList(),
            Conditions = character.Conditions.Select(condition => new CharacterCondition { ConditionId = condition.ConditionId }).ToList(),
        };

        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();
        
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int? id)
    {
        if (id == null) { return NotFound(); }

        var character = await _context.Characters.FindAsync(id);
        if (character == null) { return NotFound(); }

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();

        // Redirect to the index page after deletion
        return RedirectToPage();
    }
}