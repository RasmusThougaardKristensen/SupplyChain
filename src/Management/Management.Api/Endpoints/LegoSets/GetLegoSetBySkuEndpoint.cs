using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Application.UseCases.LegoSets;
using SupplyChain.Management.Domain.LegoSets;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.LegoSets;

[ApiController]
public class GetLegoSetBySkuEndpoint : ControllerBase
{
    private readonly IGetLegoSetUseCase _getLegoSetUseCase;

    public GetLegoSetBySkuEndpoint(IGetLegoSetUseCase getLegoSetUseCase)
    {
        _getLegoSetUseCase = getLegoSetUseCase;
    }

    [HttpGet("v1/legoSets/{sku}")]
    [ProducesResponseType(typeof(LegoSetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Get lego set for a given SKU",
        OperationId = nameof(GetLegoSetBySku),
        Tags = [Constants.ApiTags.LegoSet])]

    public ActionResult<LegoSetResponse> GetLegoSetBySku([FromRoute] string sku)
    {
        var legoSet = _getLegoSetUseCase.GetSetBySku(new Sku(sku));

        if (legoSet is null)
        {
            return NotFound();
        }

        var response = new LegoSetResponse(legoSet);
        return Ok(response);
    }
}