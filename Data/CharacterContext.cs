using Microsoft.EntityFrameworkCore;
using DnD_Manager.Models;

namespace DnD_Manager.Data;

public class CharacterContext : DbContext
{
    public DbSet<Character> Characters { get; set; }
    public DbSet<Stat> Stats { get; set; }
    public DbSet<CharacterStat> CharacterStats { get; set; }
    public DbSet<Race> Races { get; set; }
    public DbSet<Subrace> Subraces { get; set; }
    public DbSet<Class> Classes { get; set; }
    public DbSet<CharacterClass> CharacterClasses { get; set; }
    public DbSet<Condition> Conditions { get; set; }
    public DbSet<CharacterCondition> CharacterConditions { get; set; }


    public CharacterContext(DbContextOptions<CharacterContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Character>().ToTable("Characters");
        modelBuilder.Entity<Stat>().ToTable("Stats");
        modelBuilder.Entity<CharacterStat>().ToTable("CharacterStats");
        modelBuilder.Entity<Race>().ToTable("Races");
        modelBuilder.Entity<Subrace>().ToTable("Subraces");
        modelBuilder.Entity<Class>().ToTable("Classes");
        modelBuilder.Entity<CharacterClass>().ToTable("CharacterClasses");
        modelBuilder.Entity<Condition>().ToTable("Conditions");
        modelBuilder.Entity<CharacterCondition>().ToTable("CharacterConditions");
    }

    public override int SaveChanges()
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e.State == EntityState.Added)
            .ToList();

        foreach (var entry in entries)
        {
            Console.WriteLine($"ADDING: {entry.Entity.GetType().Name}");
        }

        return base.SaveChanges();
    }
}
