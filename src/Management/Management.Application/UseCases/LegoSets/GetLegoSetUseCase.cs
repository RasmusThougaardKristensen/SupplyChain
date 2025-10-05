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

    public async Task<LegoSetModel?> GetLegoSetBySku(Sku sku)
    {
        return await _legoSetRepository.GetLegoSetBySku(sku);
    }
}