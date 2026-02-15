# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

ASP.NET Core 10.0 Blazor Server web application for managing D&D 5th Edition characters. Currently implements character management with stats, classes, skills, health tracking, and conditions. Future plans include NPCs, monsters, class/race/spell databases, and GM tools.

**Tech Stack:**
- ASP.NET Core 10.0 with Blazor Server
- Entity Framework Core 8.0
- MySQL database (Pomelo.EntityFrameworkCore.MySql provider)
- Bootstrap 5 for UI (no jQuery)

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

### Service Layer
- **[CharacterService.cs](Services/CharacterService.cs)**: All character business logic (CRUD, health management, rest mechanics, conditions). Injected as a scoped service. Contains both query methods and mutation methods, plus static helpers for calculated properties (AC, proficiency bonus, initiative, speed).

### Blazor Components

**Infrastructure:**
- [Components/App.razor](Components/App.razor): Root HTML shell
- [Components/Routes.razor](Components/Routes.razor): Router configuration
- [Components/_Imports.razor](Components/_Imports.razor): Global usings
- [Components/Layout/MainLayout.razor](Components/Layout/MainLayout.razor): Shared layout (navbar, footer)

**Pages:**
- [Components/Pages/Home.razor](Components/Pages/Home.razor): Home page (`/`)
- [Components/Pages/PlayerCharacters/CharacterList.razor](Components/Pages/PlayerCharacters/CharacterList.razor): Character list (`/characters`) with copy/delete
- [Components/Pages/PlayerCharacters/CharacterSheet.razor](Components/Pages/PlayerCharacters/CharacterSheet.razor): Character sheet (`/characters/{Id:int}`) with health, rest, conditions, tabbed sections

**Tab Components** (in `Components/Pages/PlayerCharacters/CharTabs/`):
- [AbilitiesTab.razor](Components/Pages/PlayerCharacters/CharTabs/AbilitiesTab.razor): Stats, skills, saving throws, passive senses, proficiencies
- [FeaturesTab.razor](Components/Pages/PlayerCharacters/CharTabs/FeaturesTab.razor): Class features filtered by level
- ActionsTab, InventoryTab, BackgroundTab, NotesTab: Placeholders

**Modal Components** (in `Components/Pages/PlayerCharacters/`):
- [ConditionsModal.razor](Components/Pages/PlayerCharacters/ConditionsModal.razor): Toggle conditions and exhaustion
- [RestModal.razor](Components/Pages/PlayerCharacters/RestModal.razor): Short/long rest with hit dice management
- [DefencesModal.razor](Components/Pages/PlayerCharacters/DefencesModal.razor): Resistances, immunities, vulnerabilities

### Key Patterns

1. **Database Seeding**: DbInitializer seeds comprehensive D&D reference data on startup. When adding new reference data entities, add them to DbInitializer.

2. **Navigation Properties**: Models use EF Core navigation properties extensively. The CharacterService handles eager loading via `.Include()` and `.ThenInclude()`.

3. **Service Layer**: All database operations go through `CharacterService`. Components inject the service and call its methods. No direct DbContext usage in components.

4. **Component Parameters**: Child components receive data via `[Parameter]` properties. Modal components use `EventCallback` for parent-child communication.

5. **Render Modes**: Interactive pages use `@rendermode InteractiveServer`. Static pages (Home, Privacy) use default SSR.

6. **Modals**: Managed via boolean flags in parent component state (not Bootstrap JS). Rendered conditionally with CSS `d-block` class and a backdrop div.

7. **Bootstrap JS**: Still used for navbar collapse, offcanvas (skill/condition descriptions), and gear dropdown. NOT used for modals or tabs (handled by Blazor).

8. **Calculated Properties**: Static helper methods in `CharacterService` compute AC, proficiency bonus, initiative, and speed from character data.

## Important Notes

- **Database Reset**: The application currently drops and recreates the database on every startup via `context.Database.EnsureDeleted()` in DbInitializer. This is intentional for development but should be changed before production.

- **User Secrets**: Connection strings are stored in User Secrets (UserSecretsId: 26e20400-dd23-4c0e-aaab-1778a3e186a6), not in appsettings.json.

- **MongoDB Package**: The MongoDB.Driver package is referenced but not currently used (legacy from initial design). It may be used for future API development.

- **Future Plans**: The codebase is designed to eventually support NPCs, monsters, reference data browsers (classes, races, spells), and GM tools. See [PROJECT_PLAN.md](PROJECT_PLAN.md) for the full roadmap.
