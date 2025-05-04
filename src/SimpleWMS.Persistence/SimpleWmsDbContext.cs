using Microsoft.EntityFrameworkCore;
using SimpleWMS.Domain.Entities;

namespace SimpleWMS.Persistence;

public class SimpleWmsDbContext : DbContext
{
    public SimpleWmsDbContext(DbContextOptions<SimpleWmsDbContext> options) : base(options) { }

    public DbSet<Instance> Instances => Set<Instance>();
    public DbSet<Cargo> Cargoes => Set<Cargo>();
    public DbSet<Crate> Crates => Set<Crate>();
    public DbSet<MobileContainer> MobileContainers => Set<MobileContainer>();
    public DbSet<Transportation> Transportations => Set<Transportation>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Instance>()
            .Property(i => i.Status)
            .HasConversion<int>();
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName)
            .IsUnique();
        
        modelBuilder.Entity<Cargo>()
            .Property(c => c.Status)
            .HasConversion<int>();
        
        modelBuilder.Entity<Crate>()
            .Property(c => c.Status)
            .HasConversion<int>();
        
        modelBuilder.Entity<Crate>()
            .Property(c => c.LocationCode)
            .HasConversion(v => v.Value, v => Domain.ValueObjects.CrateLocationCode.Parse(v));
        
        modelBuilder.Entity<Transportation>()
            .Property(t => t.Status)
            .HasConversion<int>();
        
        modelBuilder.Entity<MobileContainer>()
            .Property(m => m.Number)
            .HasConversion(v => v.Value, v => Domain.ValueObjects.MobileContainerNumber.Parse(v));
    }
}