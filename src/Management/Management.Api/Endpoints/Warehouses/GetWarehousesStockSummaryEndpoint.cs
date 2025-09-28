using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Application.UseCases;
using SupplyChain.Management.Application.UseCases.Warehouses;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

[ApiController]
public class GetWarehousesStockSummaryEndpoint : ControllerBase
{
    private readonly IGetWarehouseUseCase _getWarehouseUseCase;

    public GetWarehousesStockSummaryEndpoint(IGetWarehouseUseCase getWarehouseUseCase)
    {
        _getWarehouseUseCase = getWarehouseUseCase;
    }

    [HttpGet("warehouses/{location}/stock-summary")]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary = "Get a summary of a warehouse's stock. How many units in each category is currently held at the warehouse.",
        OperationId = nameof(GetWarehouseStockSummary),
        Tags = [Constants.ApiTags.Warehouse])]

    public ActionResult GetWarehouseStockSummary([FromRoute] string location)
    {
        var warehouse = _getWarehouseUseCase.GetWarehouseStockSummary(new WarehouseLocation(location));

        if (warehouse is null)
        {
            return NotFound();
        }

        return Ok(new WarehouseResponse(warehouse));
    }
}