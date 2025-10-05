using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public class LegoSetEntityConfiguration : IEntityTypeConfiguration<LegoSetEntity>
{
    public void Configure(EntityTypeBuilder<LegoSetEntity> builder)
    {
        builder.HasKey(p => p.SKU);

        builder.Property(p => p.SKU).IsRequired().ValueGeneratedNever();
        builder.Property(p => p.Name).IsRequired();
        builder.Property(p => p.Theme).IsRequired();
        builder.Property(p => p.Weight).IsRequired();
        builder.Property(p => p.Rating).IsRequired();
        builder.Property(p => p.PieceCount).IsRequired();
        builder.Property(p => p.Uom).IsRequired();
        builder.Property(p => p.ReleaseYear).IsRequired();
        builder.Property(p => p.State).IsRequired();

        builder.HasIndex(p => new { p.Theme, p.Weight, p.State }).IsUnique();

        builder.HasMany(p => p.Stocks)
            .WithOne()
            .HasForeignKey(p => p.SKU)
            .OnDelete(DeleteBehavior.Restrict);
    }
}