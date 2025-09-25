using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    LegoSetModel? GetSetBySku(Sku sku);
}