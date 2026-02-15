# D&D Manager

A D&D 5th Edition character management web application built with ASP.NET Core Blazor Server and Bootstrap 5.

## Current Features

- **Character Sheets** - View and manage player characters with a tabbed interface
- **Ability Scores & Skills** - Full stat block with modifiers, saving throws, passive senses, and skill proficiencies
- **Health Tracking** - Current/max HP, temporary HP, and hit dice management
- **Conditions** - Toggle status effects (Poisoned, Stunned, etc.) and track exhaustion levels
- **Rest Mechanics** - Short and long rests with hit dice spending
- **Class Features** - View class features filtered by character level
- **Defences** - Resistances, immunities, and vulnerabilities
- **Character List** - Browse all characters with copy and delete functionality

## Tech Stack

- **Framework:** ASP.NET Core 10.0 with Blazor Server
- **ORM:** Entity Framework Core 8.0
- **Database:** MySQL (Pomelo.EntityFrameworkCore.MySql)
- **UI:** Bootstrap 5

## Getting Started

### Prerequisites

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download)
- MySQL server

### Setup

1. Clone the repository:
   ```bash
   git clone https://github.com/rsprague216/DnD_manager.git
   cd DnD_manager
   ```

2. Configure the database connection string via User Secrets:
   ```bash
   dotnet user-secrets set "ConnectionStrings:CharacterContext" "server=localhost;database=dnd_manager;user=youruser;password=yourpassword"
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

The database is automatically created and seeded with D&D reference data (races, classes, stats, skills, conditions) on startup.

> **Note:** The app currently drops and recreates the database on every startup. This is intentional for development.

## Project Structure

```
DnD_manager/
├── Components/
│   ├── Layout/              # Shared layout (navbar, footer)
│   └── Pages/
│       ├── Home.razor       # Landing page
│       └── PlayerCharacters/
│           ├── CharacterList.razor    # Character browser
│           ├── CharacterSheet.razor   # Main character sheet
│           ├── ConditionsModal.razor   # Conditions management
│           ├── RestModal.razor         # Rest mechanics
│           ├── DefencesModal.razor     # Resistances/immunities
│           └── CharTabs/              # Tabbed sheet sections
│               ├── AbilitiesTab.razor
│               ├── FeaturesTab.razor
│               ├── ActionsTab.razor
│               ├── InventoryTab.razor
│               ├── BackgroundTab.razor
│               └── NotesTab.razor
├── Data/
│   ├── CharacterContext.cs   # EF Core DbContext
│   └── DbInitializer.cs     # Database seeding
├── Models/                   # Entity models
├── Services/
│   └── CharacterService.cs   # Business logic layer
└── PROJECT_PLAN.md           # Full development roadmap
```

## Roadmap

The project is designed to grow into a full-featured D&D companion. Planned features include:

- Character creation wizard and editing
- Combat mechanics (weapons, attacks, death saves)
- Inventory and equipment management
- Spellcasting system with spell slots and preparation
- Homebrew content creation and sharing
- GM tools (NPCs, monsters, encounter builder)
- Reference browsers (spells, classes, races, items)

See [PROJECT_PLAN.md](PROJECT_PLAN.md) for the full development roadmap.
