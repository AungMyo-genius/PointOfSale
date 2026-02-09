namespace PointOfSale.App.Models;

public sealed class InventoryItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int QuantityOnHand { get; set; }
    public int ReorderPoint { get; set; }
    public int QuantityOnOrder { get; set; }
    public string Location { get; set; } = "Main Store";
    public DateTime? LastCountedOn { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
