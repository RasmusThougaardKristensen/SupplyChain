using Microsoft.EntityFrameworkCore;
using SupplyChain.Management.Infrastructure.Repositories.LegoSets;
using SupplyChain.Management.Infrastructure.Repositories.Warehouses;

namespace SupplyChain.Management.Infrastructure.Repositories;

public sealed class ManagementDbContext : DbContext
{
    public DbSet<LegoSetEntity> LegoSet { get; set; }
    public DbSet<StockEntity> Stock { get; set; }

    public ManagementDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ManagementDbContext).Assembly);
    }
}