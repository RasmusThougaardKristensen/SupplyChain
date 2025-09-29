using SupplyChain.Management.Application.Components;
using SupplyChain.Management.Application.Repositories;
using SupplyChain.Management.Domain.LegoSets;

namespace SupplyChain.Management.Application.UseCases.LegoSets;

public class GetLegoSetUseCase : IGetLegoSetUseCase
{
    private readonly ILegoSetRepository _legoSetRepository;

    public GetLegoSetUseCase(ILegoSetRepository legoSetRepository)
    {
        _legoSetRepository = legoSetRepository;
    }

    public LegoSetModel? GetSetBySku(Sku sku)
    {
        return _legoSetRepository.GetLegoSetBySku(sku);
    }
}