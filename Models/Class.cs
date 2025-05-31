using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class Class
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Class name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Hit Die is required.")]
    [Range(6, 12, ErrorMessage = "Hit Die must be between 6 and 12.")]
    public int HitDie { get; set; } = 8;

    [Required(ErrorMessage = "Saving Throws are required.")]
    [MinLength(2, ErrorMessage = "At least two saving throw is required.")]
    public List<string> SavingThrows { get; set; } = new List<string>();

    // public Dictionary<string, bool> Skills { get; set; } = new Dictionary<string, bool>();

    // public List<string>? Tools { get; set; }

    public string Source { get; set; } = "Homebrew";

    // Dynamic properties
    public int HitPointsAtFirstLevel => HitDie;

    public int HitPointsAtHigherLevels => HitDie / 2 + 1;

    // Navigation properties
    public ICollection<CharacterClass> CharacterClasses { get; set; } = null!;
}