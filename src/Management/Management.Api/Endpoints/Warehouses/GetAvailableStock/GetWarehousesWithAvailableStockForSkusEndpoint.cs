using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Application.UseCases.Warehouses;
using SupplyChain.Management.Domain.LegoSets;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses.GetAvailableStock;

[ApiController]
public class GetWarehousesWithAvailableStockForSkusEndpoint : ControllerBase
{
    private readonly IGetWarehouseUseCase _getWarehouseUseCase;

    public GetWarehousesWithAvailableStockForSkusEndpoint(IGetWarehouseUseCase getWarehouseUseCase)
    {
        _getWarehouseUseCase = getWarehouseUseCase;
    }

    [HttpGet("v1/warehouses/stock-available")]
    [ProducesResponseType(typeof(IEnumerable<WarehouseResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary =  "Get a list of warehouses with available stock for given SKUs.",
        OperationId = nameof(GetWarehousesWithAvailableStocks),
        Tags = [Constants.ApiTags.Warehouse])]

    public ActionResult<IEnumerable<WarehouseResponse>> GetWarehousesWithAvailableStocks([FromQuery] WarehouseStockRequest request)
    {
        var requestedSkus = request.Skus.Select(sku => new Sku(sku)).ToList();
        var warehouses = _getWarehouseUseCase.GetWarehousesWithAvailableStockForSkus(requestedSkus);
        return Ok(warehouses.Select(warehouse => new WarehouseResponse(warehouse)));
    }
}