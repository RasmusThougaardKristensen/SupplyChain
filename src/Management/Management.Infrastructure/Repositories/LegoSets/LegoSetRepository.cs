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
        var setEntities = ReadLegoSetsFromCsv();

        var entity = setEntities.FirstOrDefault(setEntity => setEntity.SKU == sku.Id);

        return entity is null ? null : ToModel(entity);
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
            releaseYear: entity.ReleaseYear.ToString(),
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