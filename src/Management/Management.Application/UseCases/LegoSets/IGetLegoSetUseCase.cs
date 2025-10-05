using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.UseCases.LegoSets;

public interface IGetLegoSetUseCase
{
    Task<LegoSetModel?> GetLegoSetBySku(Sku sku);
}