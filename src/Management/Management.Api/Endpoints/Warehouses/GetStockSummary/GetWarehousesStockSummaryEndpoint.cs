using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupplyChain.Management.Api.Endpoints.Warehouses.GetAvailableStock;
using SupplyChain.Management.Application.UseCases.Warehouses.GetSummary;
using SupplyChain.Management.Domain.Warehouses;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses.GetStockSummary;

[ApiController]
public class GetWarehousesStockSummaryEndpoint : ControllerBase
{
    private readonly IGetWarehouseSummaryUseCase _getWarehouseSummaryUseCase;

    public GetWarehousesStockSummaryEndpoint(IGetWarehouseSummaryUseCase getWarehouseSummaryUseCase)
    {
        _getWarehouseSummaryUseCase = getWarehouseSummaryUseCase;
    }

    [HttpGet("warehouses/{location}/summary")]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(WarehouseResponse), StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(
        Summary = "Get a summary of a warehouse's stock. How many units in each category is currently held at the warehouse.",
        OperationId = nameof(GetWarehouseStockSummary),
        Tags = [Constants.ApiTags.Warehouse])]

    public ActionResult GetWarehouseStockSummary([FromRoute] string location)
    {
        var warehouse = _getWarehouseSummaryUseCase.GetWarehouseStockSummary(new WarehouseLocation(location));

        if (warehouse is null)
        {
            return NotFound();
        }

        return Ok(new WarehouseSummaryResponse(warehouse));
    }
}