# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ASP.NET Core 9.0 Razor Pages web application for managing D&D 5th Edition characters. Currently implements character management with stats, classes, skills, health tracking, and conditions. Future plans include NPCs, monsters, class/race/spell databases, and GM tools.

**Tech Stack:**
- ASP.NET Core 9.0 with Razor Pages
- Entity Framework Core 8.0
- MySQL database (Pomelo.EntityFrameworkCore.MySql provider)
- Bootstrap for UI

## Development Commands

### Running the Application
```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the application (launches on https://localhost:7XXX and http://localhost:5XXX)
dotnet run

# Watch mode (auto-rebuild on file changes)
dotnet watch run
```

### Database Configuration
The connection string is stored in User Secrets (not in appsettings.json). To configure:
```bash
# Set the MySQL connection string
dotnet user-secrets set "ConnectionStrings:CharacterContext" "server=localhost;database=dnd_manager;user=youruser;password=yourpassword"

# View current secrets
dotnet user-secrets list
```

### Entity Framework Migrations
**Note:** The application currently uses `EnsureDeleted()` and `EnsureCreated()` in [DbInitializer.cs](Data/DbInitializer.cs), which drops and recreates the database on every startup. This is for development only.

If switching to migrations in the future:
```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations to database
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## Architecture

### Data Layer
- **[CharacterContext.cs](Data/CharacterContext.cs)**: Main EF Core DbContext with all entity DbSets
- **[DbInitializer.cs](Data/DbInitializer.cs)**: Seeds database with D&D reference data (races, subraces, classes, stats, skills, conditions). **Currently drops and recreates database on startup**.

### Models
Core entities use a relational structure with junction tables for many-to-many relationships:

**Primary Entities:**
- [Character](Models/Character.cs): Player character with HP, level, exhaustion
- [Race](Models/Race.cs) / [Subrace](Models/Subrace.cs): Character races (Human, Elf, etc.)
- [Class](Models/Class.cs): D&D classes (Fighter, Wizard, etc.)
- [Stat](Models/Stat.cs): Ability scores (STR, DEX, CON, INT, WIS, CHA)
- [Skill](Models/Skill.cs): D&D skills (Acrobatics, Perception, etc.)
- [Condition](Models/Condition.cs): Status effects (Poisoned, Stunned, etc.)

**Junction Tables (Many-to-Many):**
- [CharacterClass](Models/CharacterClass.cs): Links characters to classes, tracks level and used hit dice
- [CharacterStat](Models/CharacterStat.cs): Links characters to stats with score and modifier values
- [CharacterSkill](Models/CharacterSkill.cs): Links characters to skills with proficiency status
- [CharacterCondition](Models/CharacterCondition.cs): Links characters to active conditions

### Pages (Razor Pages)
- **[Pages/PlayerCharacters/Index.cshtml](Pages/PlayerCharacters/Index.cshtml)**: Character list view
- **[Pages/PlayerCharacters/Character.cshtml](Pages/PlayerCharacters/Character.cshtml)**: Individual character sheet
  - Uses partial views in `Pages/PlayerCharacters/CharTabs/` for different character sheet sections
  - Page model includes calculated properties (AC, proficiency bonus, initiative, speed)

### Key Patterns

1. **Database Seeding**: DbInitializer seeds comprehensive D&D reference data on startup. When adding new reference data entities, add them to DbInitializer.

2. **Navigation Properties**: Models use EF Core navigation properties extensively. Always include appropriate `.Include()` statements when querying to eager load related data:
   ```csharp
   var character = await _context.Characters
       .Include(c => c.Stats)
       .Include(c => c.Race)
       .Include(c => c.CharacterClasses)
           .ThenInclude(cc => cc.Class)
       .FirstOrDefaultAsync(c => c.Id == id);
   ```

3. **Character Stats**: Stats are stored separately and linked via CharacterStat junction table. Each character has 6 stats (STR, DEX, CON, INT, WIS, CHA).

4. **Multiclassing**: Characters can have multiple classes through CharacterClass junction table, which tracks level and used hit dice per class.

5. **Calculated Properties**: The CharacterModel page model calculates derived stats (AC, proficiency bonus, etc.) in the code-behind rather than storing them in the database.

## Important Notes

- **Database Reset**: The application currently drops and recreates the database on every startup via `context.Database.EnsureDeleted()` in Program.cs. This is intentional for development but should be changed before production.

- **User Secrets**: Connection strings are stored in User Secrets (UserSecretsId: 26e20400-dd23-4c0e-aaab-1778a3e186a6), not in appsettings.json.

- **MongoDB Package**: The MongoDB.Driver package is referenced but not currently used (legacy from initial design). It may be used for future API development.

- **Future Plans**: The codebase is designed to eventually support NPCs, monsters, reference data browsers (classes, races, spells), and GM tools.
