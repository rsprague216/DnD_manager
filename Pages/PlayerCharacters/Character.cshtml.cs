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
    public int ArmorClass => CalcArmorClass();

    [BindProperty]
    public int HealthAdj { get; set; }

    [BindProperty]
    public Dictionary<int, int> UsedHitDiceCounts { get; set; } = new();

    [BindProperty]
    public List<int> SelectedConditionIds { get; set; } = default!;

    [BindProperty]
    public int ExhaustionLevel { get; set; } = 0;


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

    // **************** APPLY DAMAGE ****************
    public async Task<IActionResult> OnPostDamageAsync(int? id)
    {
        // Validate the ID
        if (id == null) { return NotFound(); }

        // Find the character by ID
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null) { return NotFound(); }


        // Adjust the character's health
        if (character.TemporaryHitPoints > 0)
        {
            if (HealthAdj >= character.TemporaryHitPoints)
            {
                // If the damage is greater than or equal to temporary hit points, remove them
                HealthAdj -= character.TemporaryHitPoints;
                character.TemporaryHitPoints = 0;
            }
            else
            {
                // Otherwise, just reduce the temporary hit points
                character.TemporaryHitPoints -= HealthAdj;
                HealthAdj = 0; // No more damage to apply
            }
            character.CurrentHitPoints = Math.Max(0, character.CurrentHitPoints - HealthAdj);
        }
        else
        {
            // Otherwise, reduce the current hit points
            character.CurrentHitPoints = Math.Max(0, character.CurrentHitPoints - HealthAdj);
        }

        // Update the character in the database
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();

        // Redirect to the character page
        return RedirectToPage(new { id = character.Id });
    }

    // **************** APPLY HEALING ****************
    public async Task<IActionResult> OnPostHealAsync(int? id)
    {
        // Validate the ID
        if (id == null) { return NotFound(); }

        // Find the character by ID
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        if (character == null) { return NotFound(); }

        // Adjust the character's health
        character.CurrentHitPoints = Math.Min(character.HitPoints, character.CurrentHitPoints + HealthAdj);

        // Update the character in the database
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();

        // Redirect to the character page
        return RedirectToPage(new { id = character.Id });
    }

    // **************** ADJUST TEMPORARY HIT POINTS ****************
    public async Task<IActionResult> OnPostTempHPAsync(int? id)
    {
        // Validate the ID
        if (id == null) { return NotFound(); }

        // Find the character by ID
        var character = await _context.Characters.FirstOrDefaultAsync(character => character.Id == id);
        if (character == null) { return NotFound(); }

        // Adjust the character's temporary hit points
        character.TemporaryHitPoints = Math.Max(character.TemporaryHitPoints, HealthAdj);

        // Update the character in the database
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();

        // Redirect to the character page
        return RedirectToPage(new { id = character.Id });
    }

    // ***************** SHORT REST ****************
    public async Task<IActionResult> OnPostShortRestAsync(int? id)
    {
        // Validate the ID
        Console.WriteLine("In OnPostShortRestAsync");
        if (id == null) { return NotFound(); }

        Console.WriteLine($"UsedHitDiceCounts: {string.Join(", ", UsedHitDiceCounts.Select(kvp => $"{kvp.Key}: {kvp.Value}"))}");

        // Find the Character by ID
        var character = await _context.Characters
            .Include(c => c.CharacterClasses)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character == null) { return NotFound(); }

        character.TemporaryHitPoints = 0; // Reset temporary hit points

        // Update the character's used hit dice counts
        if (UsedHitDiceCounts != null)
        {
            foreach (var count in UsedHitDiceCounts)
            {
                var charClass = character.CharacterClasses
                    .FirstOrDefault(charClass => charClass.Id == count.Key);

                if (charClass != null)
                {
                    charClass.UsedHitDice = count.Value;
                }
            }
            await _context.SaveChangesAsync();
        }

        return RedirectToPage(new { id = character.Id });
    }

    // ***************** LONG REST ****************
    public async Task<IActionResult> OnPostLongRestAsync(int? id)
    {
        // Validate the ID
        if (id == null) { return NotFound(); }

        // Find the character by ID
        var character = await _context.Characters
            .Include(c => c.CharacterClasses)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character == null) { return NotFound(); }

        // Reset used hit dice counts and restore health
        foreach (var charClass in character.CharacterClasses)
        {
            charClass.UsedHitDice = 0; // Reset used hit dice
        }

        character.CurrentHitPoints = character.HitPoints; // Restore health to max
        character.TemporaryHitPoints = 0; // Reset temporary hit points
        character.ExhaustionLevel = Math.Max(0, character.ExhaustionLevel - 1); // Reduce exhaustion level

        // Update the character in the database
        _context.Characters.Update(character);
        await _context.SaveChangesAsync();

        // Redirect to the character page
        return RedirectToPage(new { id = character.Id });
    }

    // **************** TOGGLE CONDITIONS ****************
    public async Task<IActionResult> OnPostToggleConditionAsync(int? id)
    {
        // Validate Ids
        if (id == null) { return NotFound(); }
        Console.WriteLine($"SelectedConditionIds: {string.Join(", ", SelectedConditionIds)}");

        // Find the character by ID
        var character = await _context.Characters
            .Include(c => c.Conditions)
            .FirstOrDefaultAsync(c => c.Id == id);
        if (character == null) { return NotFound(); }

        // Clear existing conditions
        var existingConditions = _context.CharacterConditions
            .Where(charCondition => charCondition.CharacterId == character.Id);
        _context.CharacterConditions.RemoveRange(existingConditions);

        // Add selected conditions
        var toAdd = SelectedConditionIds
            .Select(condId => new CharacterCondition
            {
                CharacterId = character.Id,
                ConditionId = condId
            });
        _context.CharacterConditions.AddRange(toAdd);

        character.ExhaustionLevel = ExhaustionLevel;
        _context.Characters.Update(character);

        await _context.SaveChangesAsync();

        // Redirect to the character page
        return RedirectToPage(new { id = character.Id });
    }


    // Private helper methods
    private int CalcArmorClass()
    {
        var dexStat = Character.Stats.FirstOrDefault(stat => stat.Stat.Abbreviation == "Dex");
        int dex = dexStat?.Modifier ?? 0;


        return 10 + dex; // Base AC + Dex modifier
    }
}