namespace SupplyChain.Management.Domain.Warehouses.Stocks;

public sealed record StockPlacement
{
    public int Placement { get; }
    public int Shelf { get; }

    public StockPlacement(int placement, int shelf)
    {
        Placement = placement;
        Shelf = shelf;
    }
}