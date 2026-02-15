using DnD_Manager.Models;
using Microsoft.AspNetCore.Identity;

namespace DnD_Manager.Data;

public static partial class DbInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<CharacterContext>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        // Seed roles
        string[] roles = { "Player", "DM", "Admin" };
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        // Seed default admin user (for development)
        var adminEmail = "admin@dndmanager.local";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                DisplayName = "Admin",
                EmailConfirmed = true
            };
            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        if (context.Races.Any()) { return; } // DB has been seeded

        // Seed reference data
        var races = SeedRaces(context);
        SeedSubraces(context, races);
        var classes = SeedClasses(context);
        SeedClassFeatures(context, classes);
        var stats = SeedStats(context);
        var skills = SeedSkills(context, stats);
        var conditions = SeedConditions(context);


    }
}
