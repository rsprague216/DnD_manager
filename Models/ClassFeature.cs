using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DnD_Manager.Models;

public class ClassFeature
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Feature name is required.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; } = string.Empty;

    [Required(ErrorMessage = "Feature Level is required.")]
    public int FeatureLevel { get; set; } = 1;


    public int ClassId { get; set; }

    // Navigation properties
    public Class Class { get; set; } = null!;

}