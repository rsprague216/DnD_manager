# Plan: D&D 5e SRD API Integration

## Context

All D&D reference data (races, classes, stats, skills, conditions, etc.) is currently hardcoded in local seeder files. The D&D 5e SRD API (`https://www.dnd5eapi.co/api/2014/`) provides this same data via REST endpoints. This change migrates reference data to be sourced from the API and cached in the local MySQL database, so the local DB is reserved for user-created content (characters). Non-SRD content (Aasimar, Blood Hunter, Artificer) will be dropped.

---

## Architecture

### New Service Layer (`Services/DndApi/`)

| File | Purpose |
|---|---|
| `DndApiDtos.cs` | Record types matching API JSON responses |
| `IDndApiService.cs` | Interface for HTTP calls to the 5e API |
| `DndApiService.cs` | `HttpClient`-based implementation |
| `SrdCacheService.cs` | Fetches API data and upserts into local DB |

### Sync Strategy
- Runs at startup in `Program.cs` (same pattern as `DbInitializer.InitializeAsync`) — data is ready before serving requests
- On first run: fetches all reference data from API, populates DB
- On subsequent runs: fetches API data and upserts (using `ApiIndex` as the stable key)
- If API is unreachable: logs warning, app starts with existing cached data

### Data Flow
```
API (dnd5eapi.co) → DndApiService → SrdCacheService → MySQL (cached)
                                                            ↑
Components → CharacterService → EF Core queries ───────────┘
```
Components and `CharacterService` are **unchanged** — they read from the same EF models as before.

---

## Model Changes

Add two fields to all 7 reference models (`Condition`, `Stat`, `Skill`, `Race`, `Subrace`, `Class`, `ClassFeature`):

```csharp
public string? ApiIndex { get; set; }        // e.g. "blinded", "barbarian"
public DateTime? ApiUpdatedAt { get; set; }  // from API's updated_at field
```

Add filtered unique indexes in `CharacterContext.OnModelCreating`:
```csharp
modelBuilder.Entity<Condition>().HasIndex(e => e.ApiIndex).IsUnique().HasFilter("ApiIndex IS NOT NULL");
// ... same for all 7 entities
```

No changes to user-data models (`Character`, `CharacterClass`, `CharacterStat`, `CharacterSkill`, `CharacterCondition`).

---

## API Response Mapping

| API Endpoint | Local Model | Key Mappings |
|---|---|---|
| `/conditions/{index}` | `Condition` | `name→Name`, `desc[]→Description` (joined with `\n`) |
| `/ability-scores/{index}` | `Stat` | `full_name→Name`, `desc[]→Description` |
| `/skills/{index}` | `Skill` | `name→Name`, `desc[]→Description`, `ability_score.index` → resolve `StatId` |
| `/races/{index}` | `Race` | `name→Name`, `speed→Speed`, `size→Size`, `languages[].name→Languages` |
| `/subraces/{index}` | `Subrace` | `name→Name`, `desc→Description`, `race.index` → resolve `RaceId` |
| `/classes/{index}` | `Class` | `name→Name`, `hit_die→HitDie`, `saving_throws[].index` → resolve to stat names for `SavingThrows` |
| `/classes/{index}/levels` → `/features/{index}` | `ClassFeature` | `name→Name`, `desc[]→Description`, `level→FeatureLevel`, resolve `ClassId` |

---

## Implementation Phases

### Phase 1: Infrastructure
1. Add `ApiIndex` and `ApiUpdatedAt` to all 7 reference models
2. Add unique indexes in `CharacterContext.OnModelCreating`
3. Create migration: `dotnet ef migrations add AddApiCacheFields`
4. Create `Services/DndApi/DndApiDtos.cs` — API response DTOs
5. Create `Services/DndApi/IDndApiService.cs` and `DndApiService.cs` — HTTP client
6. Register `HttpClient<IDndApiService>` in `Program.cs` with base address `https://www.dnd5eapi.co/api/2014/`

**Verify:** App builds and runs with no behavior change. Existing seeders still work.

### Phase 2: Conditions (proof of concept)
1. Create `Services/DndApi/SrdCacheService.cs` with `SyncConditionsAsync`
2. Call `SrdCacheService.SyncAllAsync()` from `Program.cs` startup (after `DbInitializer`)
3. Remove `SeedConditions` call from `DbInitializer.cs`
4. Delete `Data/Seeders/ConditionSeedData.cs`

**Verify:** Start app, check that conditions appear in the character sheet's conditions modal.

### Phase 3: Stats and Skills
1. Add `SyncAbilityScoresAsync` and `SyncSkillsAsync` to `SrdCacheService`
2. Stats must sync before Skills (Skills reference `StatId`)
3. Remove `SeedStats`/`SeedSkills` calls from `DbInitializer.cs`
4. Delete `Data/Seeders/StatSeedData.cs` and `SkillSeedData.cs`

**Verify:** Abilities tab shows correct stats/skills. `CalcArmorClass()` and `CalcInitiative()` still work (they use `Stat.Abbreviation` which is computed from `Name`).

### Phase 4: Races and Subraces
1. Add `SyncRacesAsync` (includes subraces) to `SrdCacheService`
2. Races sync before Subraces (FK dependency)
3. Remove `SeedRaces`/`SeedSubraces` calls from `DbInitializer.cs`
4. Delete `Data/Seeders/RaceSeedData.cs`

**Verify:** Character list shows correct race names. `CalcSpeed()` works correctly.

### Phase 5: Classes and Class Features
1. Add `SyncClassesAsync` to `SrdCacheService`
2. For each class: fetch `/classes/{index}`, then `/classes/{index}/levels`, then each feature via `/features/{index}`
3. `Class.SavingThrows` populated by resolving `saving_throws[].index` → local `Stat.Name` (e.g., "str" → "Strength")
4. Remove `SeedClasses`/`SeedClassFeatures` calls from `DbInitializer.cs`
5. Delete `Data/Seeders/ClassSeedData.cs`

**Verify:** Features tab shows correct features at correct levels. `GetProficientSaves()` returns correct saving throws.

### Phase 6: Cleanup
1. Remove the `if (context.Races.Any()) return;` guard and all seed method calls from `DbInitializer.cs` (keep only roles/admin user seeding)
2. Delete `Data/Seeders/` directory entirely
3. Remove `partial` keyword from `DbInitializer` class declaration

---

## Files Modified

| File | Change |
|---|---|
| `Models/Condition.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/Stat.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/Skill.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/Race.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/Subrace.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/Class.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Models/ClassFeature.cs` | Add `ApiIndex`, `ApiUpdatedAt` |
| `Data/CharacterContext.cs` | Add unique indexes for `ApiIndex` |
| `Data/DbInitializer.cs` | Remove seed method calls, remove `partial` |
| `Program.cs` | Register HttpClient + SrdCacheService, call sync at startup |

## Files Created

| File | Purpose |
|---|---|
| `Services/DndApi/DndApiDtos.cs` | API response record types |
| `Services/DndApi/IDndApiService.cs` | HTTP client interface |
| `Services/DndApi/DndApiService.cs` | HTTP client implementation |
| `Services/DndApi/SrdCacheService.cs` | Sync/cache logic |

## Files Deleted

| File | Reason |
|---|---|
| `Data/Seeders/ConditionSeedData.cs` | Replaced by API sync |
| `Data/Seeders/StatSeedData.cs` | Replaced by API sync |
| `Data/Seeders/SkillSeedData.cs` | Replaced by API sync |
| `Data/Seeders/RaceSeedData.cs` | Replaced by API sync |
| `Data/Seeders/ClassSeedData.cs` | Replaced by API sync |

---

## Error Handling

- `DndApiService.GetAsync<T>()` catches all exceptions, logs warning, returns `null`
- `SrdCacheService.SyncAllAsync()` wraps each resource sync in try/catch — failure of one resource doesn't block others
- Startup caller in `Program.cs` catches sync failure and logs error — app starts with whatever cached data exists
- First run with no cached data AND API down = app starts with empty reference tables (documented limitation)

---

## Verification (End-to-End)

1. `dotnet build` — no errors
2. `dotnet run` — app starts, logs show "SRD cache sync starting..." and "SRD cache sync complete"
3. Navigate to `/characters` → character list loads correctly
4. Navigate to a character sheet → all tabs work (abilities, features, conditions modal)
5. Stop app, restart → sync runs again, no duplicate rows created (idempotent)
6. Disconnect network, restart → app starts with cached data, logs sync warning
