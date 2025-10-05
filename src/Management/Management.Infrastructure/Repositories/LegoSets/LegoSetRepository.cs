using System.Globalization;
using CsvHelper;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public sealed class LegoSetRepository : ILegoSetRepository
{
    private const string legoSetsPath = "/Users/rasmuskristensen/RiderProjects/SupplyChain/src/Management/Management.Infrastructure/Repositories/Legosets/sets.csv";


    public LegoSetModel? GetLegoSetBySku(Sku sku)
    {
        var legoSetEntities = ReadLegoSetsFromCsv();

        var entity = legoSetEntities.FirstOrDefault(setEntity => setEntity.SKU == sku.Id);

        return entity is null ? null : ToModel(entity);
    }

    public IReadOnlyList<LegoSetModel> GetLegoSetBySkus(IReadOnlyList<Sku> skus)
    {
        var legoSetEntities = ReadLegoSetsFromCsv();

        return legoSetEntities.Where(legoSet => skus.Contains(new Sku(legoSet.SKU)))
            .Select(ToModel)
            .ToList();
    }

    public IReadOnlyList<LegoSetModel> GetLegoSetsByWeight(IReadOnlyList<Sku> requestedSkus, int minWeight, int maxWeight)
    {
        var legoSetEntities = ReadLegoSetsFromCsv();

        var filteredLegoSets = legoSetEntities
            .Where(legoSet => requestedSkus.Contains(new Sku(legoSet.SKU)))
            .Where(legoSet => legoSet.Weight >= minWeight
                              && legoSet.Weight <= maxWeight)
            .Select(ToModel)
            .ToList();

        return filteredLegoSets;
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
    private static IReadOnlyList<LegoSetEntity> ReadLegoSetsFromCsv()
    {
        using var reader = new StringReader(File.ReadAllText(legoSetsPath));
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        csv.Context.RegisterClassMap<LegoSetCsvMap>();
        var setEntities = csv.GetRecords<LegoSetEntity>();

        return setEntities.ToList();
    }
}