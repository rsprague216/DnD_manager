using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson.Serialization.Attributes;

namespace DnD_Manager.Models;

public class Race
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Race name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Size is required.")]
    public string Size { get; set; } = string.Empty;

    [Required(ErrorMessage = "Speed is required.")]
    public int Speed { get; set; }

    public int? MaxAge { get; set; }

    [MinLength(1, ErrorMessage = "At least one language is required.")]
    public List<string> Languages { get; set; } = new List<string>();

    // [MinLength(1, ErrorMessage = "At least one trait is required.")]
    // public List<string> Traits { get; set; } = new List<string>();

    public String Source { get; set; } = "Homebrew";


    // Navigation properties
    public ICollection<Subrace> Subraces { get; set; } = null!;
}