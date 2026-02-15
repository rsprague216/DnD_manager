using Microsoft.AspNetCore.Identity;

namespace DnD_Manager.Models;

public class ApplicationUser : IdentityUser
{
    public string? DisplayName { get; set; }

    // Navigation properties
    public ICollection<Character> Characters { get; set; } = new List<Character>();
}
