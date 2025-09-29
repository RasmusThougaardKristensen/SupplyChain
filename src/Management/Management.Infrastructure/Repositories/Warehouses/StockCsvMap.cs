using CsvHelper.Configuration;
using SupplyChain.Management.Infrastructure.Datasets;

namespace SupplyChain.Management.Infrastructure.Repositories.Warehouses;

public sealed class StockCsvMap : ClassMap<StockEntity>
{
    public StockCsvMap()
    {
        Map(m => m.Warehouse).Name("warehouse");
        Map(m => m.SKU).Name("SKU");
        Map(m => m.Quantity).Name("quantity");
        Map(m => m.DeliveryDate).Name("delivery_date");
        Map(m => m.Uom).Name("uom");
        Map(m => m.Placement).Name("placement");
        Map(m => m.Shelf).Name("shelf");
    }
}