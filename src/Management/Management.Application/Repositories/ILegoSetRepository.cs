using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.Repositories;

public interface ILegoSetRepository
{
    public LegoSetModel? GetLegoSetBySku(Sku sku);
}