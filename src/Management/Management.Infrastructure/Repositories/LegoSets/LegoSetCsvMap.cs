using CsvHelper.Configuration;

namespace SupplyChain.Management.Infrastructure.Repositories.LegoSets;

public sealed class LegoSetCsvMap : ClassMap<LegoSetEntity>
{
    public LegoSetCsvMap()
    {
        Map(m => m.SKU).Name("SKU");
        Map(m => m.Name).Name("name");
        Map(m => m.Theme).Name("theme");
        Map(m => m.Weight).Name("weight");
        Map(m => m.Rating).Name("rating");
        Map(m => m.PieceCount).Name("piece_count");
        Map(m => m.Uom).Name("uom");
        Map(m => m.ReleaseYear).Name("release_year");
        Map(m => m.State).Name("state");
    }
}