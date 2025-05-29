using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class CharacterClass
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int CharacterId { get; set; }

    public int ClassId { get; set; }

    public int Level { get; set; } = 1;

    public int UsedHitDice { get; set; } = 0;

    // Navigation properties
    public Character Character { get; set; } = null!;
    public Class Class { get; set; } = null!;
}