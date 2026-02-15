# D&D Manager - Progress Report

## Phase 0: User Authentication & Account Management

**Status:** Complete
**Date:** 2026-02-14

### Overview

Added ASP.NET Core Identity authentication to establish user accounts, character ownership, and role-based access control. Migrated the database strategy from drop/recreate (`EnsureDeleted`/`EnsureCreated`) to EF Core Migrations for persistent data.

### Features Implemented

- **User registration** with display name, email, and password
- **Login/logout** with cookie-based authentication and "remember me" option
- **Account management** page for changing display name and password
- **Character ownership** — every character is linked to a user via `UserId` foreign key
- **Role-based access control** — three roles seeded: Player, DM, Admin
- **Authorization enforcement** — character list and character sheet pages require authentication; character sheet verifies ownership before displaying
- **Stub email sender** — logs email content to console (ready to swap in SendGrid/SMTP later)
- **EF Core Migrations** — database schema changes are now tracked and applied incrementally

### Default Dev Account

| Field    | Value                      |
|----------|----------------------------|
| Email    | `admin@dndmanager.local`   |
| Password | `Admin123!`                |
| Role     | Admin                      |

All 5 seeded characters are assigned to this account.

### Files Added

| File | Purpose |
|------|---------|
| `Models/ApplicationUser.cs` | User entity extending `IdentityUser` with `DisplayName` property |
| `Services/StubEmailSender.cs` | `IEmailSender<ApplicationUser>` implementation that logs to console |
| `Components/Pages/Account/Login.razor` | Login page (`/account/login`) |
| `Components/Pages/Account/Register.razor` | Registration page (`/account/register`) |
| `Components/Pages/Account/Logout.razor` | Logout endpoint (`/account/logout`) |
| `Components/Pages/Account/Manage.razor` | Account settings (`/account/manage`) — change password, display name |
| `Migrations/` | EF Core migration files for initial schema + Identity tables |

### Files Modified

| File | Changes |
|------|---------|
| `DnD_Manager.csproj` | Added `Microsoft.AspNetCore.Identity.EntityFrameworkCore` v8.0.13 |
| `Models/Character.cs` | Added `UserId` (required FK) and `User` navigation property |
| `Data/CharacterContext.cs` | Changed base class from `DbContext` to `IdentityDbContext<ApplicationUser>`, added `base.OnModelCreating()` call |
| `Data/DbInitializer.cs` | Removed `EnsureDeleted`/`EnsureCreated`, made async, accepts `IServiceProvider`, seeds roles + admin user, guards with `if (!context.Races.Any())` |
| `Program.cs` | Added Identity services, cookie config, auth/authorization middleware, `Database.Migrate()`, stub email sender registration |
| `Components/App.razor` | Wrapped `<Routes />` in `<CascadingAuthenticationState>` |
| `Components/_Imports.razor` | Added `Microsoft.AspNetCore.Authorization` and `Microsoft.AspNetCore.Components.Authorization` usings |
| `Components/Layout/MainLayout.razor` | Added `<AuthorizeView>` in navbar showing login/register or user info/logout |
| `Components/Pages/PlayerCharacters/CharacterList.razor` | Added `[Authorize]`, filters characters by current user, ownership check on copy/delete |
| `Components/Pages/PlayerCharacters/CharacterSheet.razor` | Added `[Authorize]`, verifies character ownership before displaying |
| `Services/CharacterService.cs` | Added `GetCharactersByUserAsync()`, `IsCharacterOwnerAsync()`, updated `CopyCharacterAsync()` to accept `userId` |

### Database Changes

- **Migration:** `InitialIdentity` — creates all application tables + ASP.NET Identity tables (`AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, `AspNetUserClaims`, `AspNetRoleClaims`, `AspNetUserLogins`, `AspNetUserTokens`)
- **Characters table** now includes `UserId` column with FK to `AspNetUsers`
- **Seeded roles:** Player, DM, Admin
- **Seeded admin user:** `admin@dndmanager.local` with Admin role

### Architecture Decisions

1. **Custom Blazor auth pages** instead of scaffolded Identity UI — auth pages use static SSR (no `@rendermode InteractiveServer`) since `SignInManager`/`UserManager` require `HttpContext`
2. **Cookie authentication** with configurable login/logout/access-denied paths
3. **Ownership enforced at both service and component level** — service provides `IsCharacterOwnerAsync()`, components verify before mutations
4. **Stub email sender** — satisfies Identity's email requirement without external dependencies; swap in real provider when ready

### Deferred / Optional (Not Implemented)

- Two-factor authentication (2FA)
- External OAuth providers (Google, Discord, GitHub)
- Email verification (stubbed — auto-confirms on registration)
- Password reset via email (infrastructure ready but no UI page yet)

### Verification Steps

1. `dotnet build` — 0 errors, 0 warnings
2. `dotnet ef database update` — migration applies cleanly
3. `dotnet run` — app starts, seeds roles and admin user on first run
4. Navigate to `/characters` — redirects to `/account/login` if not authenticated
5. Register a new account — redirects to character list (empty)
6. Login as `admin@dndmanager.local` / `Admin123!` — shows 5 seeded characters
7. Direct URL to another user's character — redirects back to character list
