using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;

namespace SupplyChain.Management.Application.UseCases;

public class GetSetUseCase : IGetSetUseCase
{
    private readonly ICsvComponent _csvComponent;

    public GetSetUseCase(ICsvComponent csvComponent)
    {
        _csvComponent = csvComponent;
    }

    public SetModel? GetSetBySku(Sku sku)
    {
        return _csvComponent.GetSetBySku(sku);
    }
}