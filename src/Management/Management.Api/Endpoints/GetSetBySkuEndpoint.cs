using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Application.UseCases;
using SupplyChain.Management.Domain.LegoSet;

namespace SupplyChain.Management.Api.Endpoints;

[ApiController]
public class GetSetBySkuEndpoint : ControllerBase
{
    private readonly IGetSetUseCase _getSetUseCase;

    public GetSetBySkuEndpoint(IGetSetUseCase getSetUseCase)
    {
        _getSetUseCase = getSetUseCase;
    }

    [HttpGet("v1/sets/{sku}")]
    [ProducesResponseType(typeof(SetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

    public ActionResult<SetResponse> GetSetBySku([FromRoute] string sku)
    {
        var set = _getSetUseCase.GetSetBySku(new Sku(sku));

        if (set is null)
        {
            return NotFound();
        }

        var response = new SetResponse(set);
        return Ok(response);
    }
}