namespace PointOfSale.App.Models;

public sealed class InventoryAdjustment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public DateTime AdjustedOn { get; set; } = DateTime.UtcNow;
    public int QuantityChanged { get; set; }
    public InventoryAdjustmentReason Reason { get; set; }
    public string? Notes { get; set; }
}

public enum InventoryAdjustmentReason
{
    Damage,
    Theft,
    Correction,
    Expiry,
    CountVariance
}
