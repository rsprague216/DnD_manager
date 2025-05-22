using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class CharacterCondition
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int CharacterId { get; set; }
    public int ConditionId { get; set; }

    // public bool Active { get; set; } = false;

    // Navigation properties
    public Character Character { get; set; } = null!;
    public Condition Condition { get; set; } = null!;
}