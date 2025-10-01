using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Domain.ClearanceSale;

public interface IWarehouseClearanceResultMapper
{
    WarehouseClearanceResult ToClearanceItems(IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets);
}