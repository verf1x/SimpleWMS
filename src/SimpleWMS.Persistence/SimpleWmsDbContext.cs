using Microsoft.EntityFrameworkCore;
using SimpleWMS.Domain.Entities;

namespace SimpleWMS.Persistence;

public class SimpleWmsDbContext : DbContext
{
    public SimpleWmsDbContext(DbContextOptions<SimpleWmsDbContext> options) : base(options) { }

    public DbSet<Instance> Instances => Set<Instance>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Instance>()
            .Property(i => i.Status)
            .HasConversion<int>();
        
        modelBuilder.Entity<User>()
            .HasIndex(u => u.UserName).IsUnique();
    }
}