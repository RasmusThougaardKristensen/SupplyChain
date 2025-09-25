using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;

namespace SupplyChain.Management.Application.UseCases;

public interface IGetSetUseCase
{
    SetModel? GetSetBySku(Sku sku);
}