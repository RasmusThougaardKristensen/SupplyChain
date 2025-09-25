using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;

namespace SupplyChain.Management.Application.Components;

public interface ICsvComponent
{
    SetModel? GetSetBySku(Sku sku);
}