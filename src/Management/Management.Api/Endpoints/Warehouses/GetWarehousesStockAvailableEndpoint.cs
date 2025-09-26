using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.LegoSets;
using SupplyChain.Management.Application.UseCases;
using SupplyChain.Management.Domain.LegoSets;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

[ApiController]
public class GetWarehousesStockAvailableEndpoint : ControllerBase
{
    private readonly IGetWarehouseUseCase _getWarehouseUseCase;

    public GetWarehousesStockAvailableEndpoint(IGetWarehouseUseCase getWarehouseUseCase)
    {
        _getWarehouseUseCase = getWarehouseUseCase;
    }

    [HttpGet("v1/warehouses/stock-available")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Get a list of warehouses with available stock for given SKUs. Available are based on the state of the lego set",
        OperationId = nameof(GetWarehousesStockAvailable),
        Tags = [Constants.ApiTags.Warehouse])]

    public ActionResult<LegoSetResponse> GetWarehousesStockAvailable([FromQuery] WarehouseStockRequest request)
    {
        var warehouses = _getWarehouseUseCase.GetWarehouses(new Sku(request.Sku), StateType.From(request.State));

        var response = warehouses.Select(warehouse => new WarehouseResponse(warehouse));
        return Ok(response);
    }
}