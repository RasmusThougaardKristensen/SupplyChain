using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public class StockEntityConfiguration : IEntityTypeConfiguration<StockEntity>
{
    public void Configure(EntityTypeBuilder<StockEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(p => p.Id).IsRequired().ValueGeneratedNever();
        builder.Property(p => p.Warehouse).IsRequired();
        builder.Property(p => p.SKU).IsRequired();
        builder.Property(p => p.Quantity).IsRequired();
        builder.Property(p => p.DeliveryDate).IsRequired();
        builder.Property(p => p.Uom).IsRequired();
        builder.Property(p => p.Placement).IsRequired();
        builder.Property(p => p.Shelf).IsRequired();

        builder.HasIndex(p => new { p.Warehouse, p.SKU, p.Quantity });

        builder.HasOne(s => s.LegoSet)
            .WithMany()
            .HasForeignKey(s => s.SKU)
            .OnDelete(DeleteBehavior.Restrict);
    }
}