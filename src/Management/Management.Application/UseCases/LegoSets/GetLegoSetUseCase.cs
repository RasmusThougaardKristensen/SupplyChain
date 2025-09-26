using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.UseCases.LegoSets;

public class GetLegoSetUseCase : IGetLegoSetUseCase
{
    private readonly ICsvComponent _csvComponent;

    public GetLegoSetUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public LegoSetModel? GetSetBySku(Sku sku)
    {
        return _csvComponent.GetSetBySku(sku);
    }
}