using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class Character
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Character name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Character race is required.")]
    public int RaceId { get; set; }

    public int? SubraceId { get; set; }

    public int HitPoints { get; set; } = 0;
    public int CurrentHitPoints { get; set; } = 0;
    public int TemporaryHitPoints { get; set; } = 0;

    [Range(0, 6)]
    public int ExhaustionLevel { get; set; } = 0;

    // Navigation properties
    public ICollection<CharacterStat> Stats { get; set; } = null!;
    public Race Race { get; set; } = null!;
    public Subrace? Subrace { get; set; }
    public ICollection<CharacterClass> CharacterClasses { get; set; } = null!;
    public ICollection<CharacterCondition> Conditions { get; set; } = null!;
}