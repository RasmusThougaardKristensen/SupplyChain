using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Application.UseCases;
using SupplyChain.Management.Domain.LegoSet;
using SupplyChain.Management.Domain.Sets;

namespace SupplyChain.Management.Api.Endpoints;

[ApiController]
public class GetWarehousesEndpoint : ControllerBase
{
    private readonly IGetWarehouseUseCase _getWarehouseUseCase;

    public GetWarehousesEndpoint(IGetWarehouseUseCase getWarehouseUseCase)
    {
        _getWarehouseUseCase = getWarehouseUseCase;
    }

    [HttpGet("v1/warehouses")]
    [ProducesResponseType(typeof(SetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]

    public ActionResult<SetResponse> GetSetBySku(
        [FromQuery] string sku,
        [FromQuery] string state)
    {
        var warehouses = _getWarehouseUseCase.GetWarehouses(new Sku(sku), StateType.From(state));

        var response = warehouses.Select(warehouse => new WarehouseResponse(warehouse));
        return Ok(response);
    }
}