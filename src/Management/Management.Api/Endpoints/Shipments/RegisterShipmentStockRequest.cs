using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace SupplyChain.Management.Api.Endpoints.Shipments;

public record RegisterShipmentStockRequest : IValidatableObject
{
    [SwaggerSchema("Unique Stock Keeping Unit identifier for the LEGO set being shipped.")]
    public required string Sku { get; init; }

    [SwaggerSchema("Total quantity of LEGO set units being delivered in this shipment")]
    public required int Quantity { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Quantity <= 0)
        {
            yield return new ValidationResult($"Quantity must be greater than or equal to 0");
        }
    }
}