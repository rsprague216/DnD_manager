using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class Subrace
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Subrace name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Subrace description is required.")]
    public string Description { get; set; } = string.Empty;

    public int RaceId { get; set; }

    // Navigation properties
    public Race Race { get; set; } = null!;
}