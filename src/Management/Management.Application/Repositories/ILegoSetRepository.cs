using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.Repositories;

public interface ILegoSetRepository
{
    public LegoSetModel? GetLegoSetBySku(Sku sku);
    IReadOnlyList<LegoSetModel> GetLegoSetBySkus(IReadOnlyList<Sku> skus);
    IReadOnlyList<LegoSetModel> GetLegoSetsByWeight(IReadOnlyList<Sku> requestedSkus, int minWeight, int maxWeight);
}