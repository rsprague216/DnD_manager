using DnD_Manager.Data;
using DnD_Manager.Models;
using Microsoft.EntityFrameworkCore;

namespace DnD_Manager.Services;

public class CharacterService
{
    private readonly CharacterContext _context;

    public CharacterService(CharacterContext context)
    {
        _context = context;
    }

    // ==================== QUERY METHODS ====================

    public async Task<List<Character>> GetAllCharactersAsync()
    {
        return await _context.Characters
            .Include(c => c.Race)
            .Include(c => c.Subrace)
            .Include(c => c.CharacterClasses).ThenInclude(cc => cc.Class)
            .ToListAsync();
    }

    public async Task<List<Character>> GetCharactersByUserAsync(string userId)
    {
        return await _context.Characters
            .Where(c => c.UserId == userId)
            .Include(c => c.Race)
            .Include(c => c.Subrace)
            .Include(c => c.CharacterClasses).ThenInclude(cc => cc.Class)
            .ToListAsync();
    }

    public async Task<Character?> GetCharacterByIdAsync(int id)
    {
        return await _context.Characters
            .Include(c => c.Race)
            .Include(c => c.Subrace)
            .Include(c => c.Stats).ThenInclude(cs => cs.Stat)
            .Include(c => c.CharacterClasses).ThenInclude(cc => cc.Class)
                .ThenInclude(cl => cl.ClassFeatures)
            .Include(c => c.Conditions).ThenInclude(cc => cc.Condition)
            .Include(c => c.Skills).ThenInclude(cs => cs.Skill)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<bool> IsCharacterOwnerAsync(int characterId, string userId)
    {
        return await _context.Characters
            .AnyAsync(c => c.Id == characterId && c.UserId == userId);
    }

    public async Task<List<Condition>> GetAllConditionsAsync()
    {
        return await _context.Conditions.ToListAsync();
    }

    // ==================== CALCULATED PROPERTIES ====================

    public static int CalcArmorClass(Character character)
    {
        var dexStat = character.Stats.FirstOrDefault(s => s.Stat.Abbreviation == "Dex");
        return 10 + (dexStat?.Modifier ?? 0);
    }

    public static int CalcProficiencyBonus(Character character)
    {
        return (character.Level - 1) / 4 + 2;
    }

    public static int CalcInitiative(Character character)
    {
        var dexStat = character.Stats.FirstOrDefault(s => s.Stat.Abbreviation == "Dex");
        return dexStat?.Modifier ?? 0;
    }

    public static int CalcSpeed(Character character)
    {
        return character.Race.Speed;
    }

    public static List<string> GetProficientSaves(Character character)
    {
        var firstClass = character.CharacterClasses.FirstOrDefault();
        return firstClass?.Class.SavingThrows.ToList() ?? new List<string>();
    }

    // ==================== MUTATION METHODS ====================

    public async Task ApplyDamageAsync(int characterId, int damage)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        if (character.TemporaryHitPoints > 0)
        {
            if (damage >= character.TemporaryHitPoints)
            {
                damage -= character.TemporaryHitPoints;
                character.TemporaryHitPoints = 0;
            }
            else
            {
                character.TemporaryHitPoints -= damage;
                damage = 0;
            }
        }

        character.CurrentHitPoints = Math.Max(0, character.CurrentHitPoints - damage);
        await _context.SaveChangesAsync();
    }

    public async Task ApplyHealingAsync(int characterId, int healing)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        character.CurrentHitPoints = Math.Min(character.HitPoints, character.CurrentHitPoints + healing);
        await _context.SaveChangesAsync();
    }

    public async Task SetTempHPAsync(int characterId, int tempHP)
    {
        var character = await _context.Characters.FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        character.TemporaryHitPoints = Math.Max(character.TemporaryHitPoints, tempHP);
        await _context.SaveChangesAsync();
    }

    public async Task ShortRestAsync(int characterId, Dictionary<int, int> usedHitDiceCounts)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterClasses)
            .FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        character.TemporaryHitPoints = 0;

        foreach (var count in usedHitDiceCounts)
        {
            var charClass = character.CharacterClasses
                .FirstOrDefault(cc => cc.Id == count.Key);
            if (charClass != null)
            {
                charClass.UsedHitDice = count.Value;
            }
        }

        await _context.SaveChangesAsync();
    }

    public async Task LongRestAsync(int characterId)
    {
        var character = await _context.Characters
            .Include(c => c.CharacterClasses)
            .FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        foreach (var cc in character.CharacterClasses)
        {
            cc.UsedHitDice = 0;
        }

        character.CurrentHitPoints = character.HitPoints;
        character.TemporaryHitPoints = 0;
        character.ExhaustionLevel = Math.Max(0, character.ExhaustionLevel - 1);
        await _context.SaveChangesAsync();
    }

    public async Task ToggleConditionsAsync(int characterId, List<int> selectedConditionIds, int exhaustionLevel)
    {
        var character = await _context.Characters
            .Include(c => c.Conditions)
            .FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        var existingConditions = _context.CharacterConditions
            .Where(cc => cc.CharacterId == characterId);
        _context.CharacterConditions.RemoveRange(existingConditions);

        var toAdd = selectedConditionIds
            .Select(condId => new CharacterCondition
            {
                CharacterId = characterId,
                ConditionId = condId
            });
        _context.CharacterConditions.AddRange(toAdd);

        character.ExhaustionLevel = exhaustionLevel;
        await _context.SaveChangesAsync();
    }

    public async Task CopyCharacterAsync(int characterId, string userId)
    {
        var character = await _context.Characters
            .Include(c => c.Stats)
            .Include(c => c.CharacterClasses)
            .Include(c => c.Conditions)
            .Include(c => c.Skills)
            .FirstOrDefaultAsync(c => c.Id == characterId);
        if (character == null) return;

        var newCharacter = new Character
        {
            Name = character.Name + " (Copy)",
            RaceId = character.RaceId,
            SubraceId = character.SubraceId,
            HitPoints = character.HitPoints,
            CurrentHitPoints = character.CurrentHitPoints,
            UserId = userId,
            Stats = character.Stats.Select(s => new CharacterStat { StatId = s.StatId, Value = s.Value }).ToList(),
            CharacterClasses = character.CharacterClasses.Select(cc => new CharacterClass { ClassId = cc.ClassId, Level = cc.Level }).ToList(),
            Conditions = character.Conditions.Select(c => new CharacterCondition { ConditionId = c.ConditionId }).ToList(),
            Skills = character.Skills.Select(s => new CharacterSkill { SkillId = s.SkillId, Proficiency = s.Proficiency }).ToList()
        };

        _context.Characters.Add(newCharacter);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCharacterAsync(int characterId)
    {
        var character = await _context.Characters.FindAsync(characterId);
        if (character == null) return;

        _context.Characters.Remove(character);
        await _context.SaveChangesAsync();
    }
}
