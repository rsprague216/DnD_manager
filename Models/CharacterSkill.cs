using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class CharacterSkill
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int CharacterId { get; set; }
    public int SkillId { get; set; }

    public int Proficiency { get; set; } // 0 = not proficient, 1 = proficient, 2 = expertise


    // Navigation property
    public Character Character { get; set; } = null!;
    public Skill Skill { get; set; } = null!;
}