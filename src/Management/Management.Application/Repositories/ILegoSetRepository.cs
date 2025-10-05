using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.Repositories;

public interface ILegoSetRepository
{
    Task<LegoSetModel?> GetLegoSetBySku(Sku sku);
    Task<IReadOnlyList<LegoSetModel>> GetLegoSetBySkus(IReadOnlyList<Sku> requestedSkus);
    Task<IReadOnlyList<LegoSetModel>> GetLegoSetsByWeight(IReadOnlyList<Sku> requestedSkus, int minWeight, int maxWeight);
}