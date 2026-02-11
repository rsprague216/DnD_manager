# D&D Manager - Complete Feature Set & Project Scope

## Context

This plan provides a comprehensive analysis of the D&D Manager application's current state and outlines the complete feature set needed to transform it from a functional character sheet viewer into a full-featured D&D 5th Edition character management system with GM tools.

**Current State:**
The application has a solid foundation with working character sheet display, health tracking, rest mechanics, conditions, skills, and saving throws built with Razor Pages. However, for better interactivity and user experience, the project will migrate to **Blazor Server**. The existing Data layer (CharacterContext, models, DbInitializer) will be reused unchanged. Critical features like character creation, spell management, inventory, and editing capabilities are still missing and will be built using Blazor components.

**Project Vision:**
Build a comprehensive D&D 5e digital companion that supports:
- Complete character lifecycle (creation → progression → retirement)
- Full spellcasting system with spell slots and preparation
- Inventory and equipment management with magic items
- Combat mechanics (attacks, AC, initiative, death saves)
- **Homebrew content creation** (custom races, classes, spells, monsters, items, equipment)
- **Content sharing** via import/export with community library
- GM tools (NPCs, monsters, encounters, campaigns)
- Reference browsers (spells, items, classes, races)

---

## Roadmap Overview

The feature set is organized into 12 phases, prioritized from critical foundation (Phases 0-4) to advanced features (Phases 7-11):

- **Phase 0:** User Authentication & Account Management - Login, registration, password security *(CRITICAL - FOUNDATION)*
- **Phase 1:** Core Character Management - Creation, editing, leveling, proficiencies *(CRITICAL)*
- **Phase 2:** Combat & Actions - Weapons, attacks, AC, death saves, initiative *(HIGH)*
- **Phase 3:** Inventory & Equipment - Items, equipment slots, magic items, currency *(HIGH)*
- **Phase 4:** Spellcasting System - Spell database, preparation, slots, concentration *(HIGH)*
- **Phase 5:** Advanced Character Features - Subclasses, resources, resistances, feats *(MEDIUM)*
- **Phase 6:** Homebrew Content System - Create custom races, classes, spells, monsters, items *(MEDIUM-HIGH)*
- **Phase 7:** Notes, Background & Roleplay - Background system, notes, appearance *(LOW-MEDIUM)*
- **Phase 8:** GM Tools - NPCs & Monsters - NPC management, monster database, encounters *(MEDIUM)*
- **Phase 9:** Reference & Content Browsers - Spell/class/race/item browsers *(LOW-MEDIUM)*
- **Phase 10:** Advanced GM Tools - Campaigns, loot generation *(LOW)*
- **Phase 11:** Polish & Advanced Features - Dice roller, PDF export, multi-user, real-time *(LOW)*

---

For detailed implementation plans for each phase, database models, critical files, and implementation strategy, see the full plan document.

## Quick Start

**Recommended starting point:** Phase 1 - Character Creation Wizard

This foundational feature enables users to create characters through a proper UI workflow and is critical for usability.

## Key Features by Phase

### Phase 0: User Authentication & Account Management (CRITICAL - FOUNDATION)
- User registration with email verification
- Secure login/logout with password hashing (PBKDF2)
- Account management (profile, change password, email change)
- Password reset via email
- Character ownership (link characters to users)
- Role-based access control (Player/DM/Admin)
- Authorization policies for character access
- Optional: Two-factor authentication (2FA)
- Optional: External OAuth (Google, Discord, GitHub)

### Phase 1: Core Character Management (CRITICAL)
- Character Creation Wizard (multi-step: Race → Class → Stats → Skills → Background)
- Character Editing
- Level Up System (with multiclassing, ASI/Feat selection)
- Proficiency System (database-driven)

### Phase 2: Combat & Actions (HIGH)
- Weapons & Attacks with auto-calculated bonuses
- Equipment-based AC calculation
- Death Saving Throws
- Initiative Tracker

### Phase 3: Inventory & Equipment (HIGH)
- Full inventory system with weight/encumbrance
- Equipment slots and management
- Magic items with attunement and charges
- Currency tracking (5 types)

### Phase 4: Spellcasting System (HIGH)
- Comprehensive spell database (200+ SRD spells)
- Spell preparation/learning by class
- Spell slot tracking (1st-9th level)
- Concentration mechanics

### Phase 5: Advanced Character Features (MEDIUM)
- Subclasses with features
- Limited-use resources (Rage, Ki, etc.)
- Resistances/Immunities/Vulnerabilities (database)
- Vision types (database)

### Phase 6: Homebrew Content System (MEDIUM-HIGH)
- Create custom races, subraces, classes, subclasses
- Custom spells with full mechanics
- Custom monsters with CR calculator
- Custom items, weapons, armor, equipment
- Import/Export via JSON
- Public homebrew library and sharing
- Character integration with homebrew content

### Phase 7: Notes, Background & Roleplay (LOW-MEDIUM)
- Background system with personality traits
- Character notes and session logs
- Physical appearance and details

### Phase 8: GM Tools - NPCs & Monsters (MEDIUM)
- NPC management with relationship tracking
- Monster database (300+ SRD monsters)
- Encounter builder with difficulty calculator

### Phase 9: Reference & Content Browsers (LOW-MEDIUM)
- Enhanced spell browser
- Class & race browsers with progression tables
- Item/equipment browser
- Feat & background browsers

### Phase 10: Advanced GM Tools (LOW)
- Campaign management with session tracking
- Loot generator

### Phase 11: Polish & Advanced Features (LOW)
- Virtual dice roller
- PDF export
- Multi-user authentication
- Real-time updates (SignalR)
- Mobile PWA

---

## Technology Stack

**Architectural Decision: Blazor Server**
The application will use **Blazor Server** instead of traditional Razor Pages for:
- Component-based architecture (reusable UI elements)
- Real-time interactivity via SignalR (built-in)
- Smooth state management for character sheets
- C# throughout (no JavaScript context switching)
- Better UX for interactive features

**Core Stack:**
- **ASP.NET Core 9.0 Blazor Server**
- Entity Framework Core 8.0 (unchanged)
- MySQL with Pomelo provider (unchanged)
- Bootstrap 5 (works well with Blazor)
- Optional: Blazor component libraries (MudBlazor, Radzen, Blazorise)

**Recommended Additions:**
- AutoMapper (character creation)
- FluentValidation (validation rules)
- Serilog (logging)
- System.Text.Json (seed data)
- Note: SignalR is built into Blazor Server

---

## Database Strategy

**Current:** `EnsureDeleted()` + `EnsureCreated()` (drops/recreates on startup)

**Recommended Transition:**
1. Complete Phases 1-3 with current approach
2. Switch to EF Migrations before Phase 4
3. Use external JSON for large datasets (spells, monsters, items)

---

## Success Metrics

### Phase 0 (Foundation - User Accounts)
- ✅ User registration and email verification working
- ✅ Secure authentication with password hashing
- ✅ Account management functional
- ✅ Character ownership enforced
- ✅ Role-based access control implemented

### Phase 1-4 (Foundation)
- ✅ Character creation from start to finish
- ✅ Character editing and leveling
- ✅ Combat mechanics (attacks, AC, death saves)
- ✅ Full inventory management
- ✅ Complete spellcasting system

### Phase 6 (Homebrew - Key Feature)
- ✅ All content tagged Official vs Homebrew
- ✅ Create custom races, classes, spells, monsters, items
- ✅ Import/Export homebrew via JSON
- ✅ Character creation supports homebrew
- ✅ Public homebrew library functional

### Phases 7-11 (Advanced)
- ✅ Background and notes
- ✅ GM tools (NPCs, monsters, encounters)
- ✅ Reference browsers
- ✅ Optional: Campaigns, dice roller, multi-user, real-time

---

## Next Steps

1. **Architectural Migration to Blazor Server**
   - Create new Blazor Server project
   - Reuse existing Data layer (CharacterContext, models, DbInitializer) - unchanged
   - Existing Razor Pages work serves as reference for business logic
   - Fresh start recommended for clean architecture

2. **Foundation First** - Complete Phase 0 (User Authentication) before other phases
   - This is REQUIRED for character ownership and homebrew content
   - Implement authentication using Blazor components
   - Can prototype Phases 1-2 without auth initially, but must add before Phase 6

3. **Choose starting phase** after Phase 0
   - Recommended: Phase 1 (Character Creation) as Blazor wizard
   - Alternative: Phase 2 (Combat) if creating characters manually

4. **Review and adjust scope** as needed

5. **Technical setup decisions**
   - Blazor component library (MudBlazor, Radzen, Blazorise) or custom?
   - Email service provider (SendGrid, AWS SES, etc.)
   - When to switch to EF Migrations
   - External JSON for large datasets

6. **Begin implementation**
   - Set up Blazor Server project structure
   - Copy Data layer from existing project
   - Start with Phase 0.1 (User Registration & Authentication in Blazor)
   - Then Phase 1.1 (Character Creation Wizard as Blazor components)

For complete implementation details, database models, and critical file references, see the full plan at `/Users/ryan/.claude/plans/modular-dancing-pascal.md`
