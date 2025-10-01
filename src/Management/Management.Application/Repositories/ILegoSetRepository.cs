using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.Repositories;

public interface ILegoSetRepository
{
    public LegoSetModel? GetLegoSetBySku(Sku sku);
    IReadOnlyList<LegoSetModel> GetLegoSetsByWeight(IReadOnlyList<Sku> requestedSkus, int minWeight, int maxWeight);
}