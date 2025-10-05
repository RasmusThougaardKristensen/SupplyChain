using SupplyChain.Management.Domain.LegoSets;
using SupplyChain.Management.Domain.Warehouses.Stocks;

namespace SupplyChain.Management.Application.UseCases.Warehouses.GetWarehouseClearances;

public interface IWarehouseClearanceDtoMapper
{
    WarehouseClearanceDto ToClearanceItems(IReadOnlyList<Stock> stocks, IReadOnlyList<LegoSetModel> legoSets);
}