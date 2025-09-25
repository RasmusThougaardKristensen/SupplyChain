using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Application.UseCases;

public interface IGetSetUseCase
{
    LegoSetModel? GetSetBySku(Sku sku);
}