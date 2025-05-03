using Microsoft.EntityFrameworkCore;
using SimpleWMS.Domain.Entities;

namespace SimpleWMS.Infrastructure;

public class SimpleWmsDbContext : DbContext
{
    public SimpleWmsDbContext(DbContextOptions options) 
        : base(options) { }
    
    public DbSet<Container> Containers => Set<Container>();
    public DbSet<Instance> ContainerTypes => Set<Instance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Container>(config =>
        {
            config.HasKey(x => x.Id);
            config.HasIndex(x => x.ContainerBarcode).IsUnique();
            config.Property(x => x.ContainerBarcode).IsRequired();
            config.OwnsMany(x => x.Instances, inst =>
            {
                inst.WithOwner().HasForeignKey("ContainerId");
                inst.HasKey("Id");
                inst.HasIndex("PostingBarcode").IsUnique();
            });
        });
    }
}
