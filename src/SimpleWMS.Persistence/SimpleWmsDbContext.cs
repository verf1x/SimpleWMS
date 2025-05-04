using Microsoft.EntityFrameworkCore;
using Wms.Domain.Entities;

namespace SimpleWMS.Persistence;

public class SimpleWmsDbContext : DbContext
{
    public SimpleWmsDbContext(DbContextOptions<SimpleWmsDbContext> options) : base(options) { }

    public DbSet<Instance> Instances => Set<Instance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Instance>()
            .Property(i => i.Status)
            .HasConversion<int>();
    }
}