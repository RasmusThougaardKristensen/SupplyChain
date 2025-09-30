using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Warehouses;

public sealed record WarehouseStockRequest
{
    [SwaggerSchema("List of Stock Keeping Unit id of stock")]
    public required IEnumerable<string> Skus { get; init; }
}