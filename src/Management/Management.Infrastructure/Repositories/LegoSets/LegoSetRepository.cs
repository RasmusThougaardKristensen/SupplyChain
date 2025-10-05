using System.Globalization;
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public sealed class LegoSetRepository : ILegoSetRepository
{
    private readonly ManagementDbContext _dbContext;

    public LegoSetRepository(ManagementDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<LegoSetModel?> GetLegoSetBySku(Sku sku)
    {
        var entity = await _dbContext.LegoSet
            .AsNoTracking()
            .SingleOrDefaultAsync(legoSet => legoSet.SKU == sku.Id);

        return entity is null ? null : ToModel(entity);
    }

    public async Task<IReadOnlyList<LegoSetModel>> GetLegoSetBySkus(IReadOnlyList<Sku> requestedSkus)
    {
        var legoSetSkus = requestedSkus.Select(sku => sku.Id).ToHashSet();
        var entities = await _dbContext.LegoSet
            .AsNoTracking()
            .Where(legoSet => legoSetSkus.Contains(legoSet.SKU))
            .ToListAsync();

        return entities.Select(ToModel).ToList();
    }

    public async Task<IReadOnlyList<LegoSetModel>> GetLegoSetsByWeight(IReadOnlyList<Sku> requestedSkus, int minWeight, int maxWeight)
    {
        var legoSetSkus = requestedSkus.Select(sku => sku.Id).ToHashSet();

        var filteredLegoSets = await _dbContext.LegoSet
            .AsNoTracking()
            .Where(legoSet => legoSetSkus.Contains(legoSet.SKU))
            .Where(legoSet => legoSet.Weight >= minWeight && legoSet.Weight <= maxWeight)
            .ToListAsync();

        return filteredLegoSets.Select(ToModel).ToList();
    }

    private LegoSetModel ToModel(LegoSetEntity entity)
    {
        var legoSet = new LegoSetModel(
            sku: new Sku(entity.SKU),
            name: entity.Name,
            theme: entity.Theme,
            weight: entity.Weight,
            rating: entity.Rating,
            pieces: entity.PieceCount,
            uom: new Uom(entity.Uom),
            releaseYear: entity.ReleaseYear,
            state: StateType.From(entity.State));

        return legoSet;
    }
}