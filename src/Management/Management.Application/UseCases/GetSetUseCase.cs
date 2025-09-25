using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Application.UseCases;

public class GetSetUseCase : IGetSetUseCase
{
    private readonly ICsvComponent _csvComponent;

    public GetSetUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public LegoSetModel? GetSetBySku(Sku sku)
    {
        return _csvComponent.GetSetBySku(sku);
    }
}