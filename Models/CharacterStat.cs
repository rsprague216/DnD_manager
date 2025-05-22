using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class CharacterStat
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int CharacterId { get; set; }
    public int StatId { get; set; }

    [Range(0, 30, ErrorMessage = "Value must be between 0 and 30.")]
    public int Value { get; set; }

    // Dynamic properties
    public int Modifier => (int)(((double)Value - 10) / 2);

    // Navigation properties
    public Character Character { get; set; } = null!;
    public Stat Stat { get; set; } = null!;
}