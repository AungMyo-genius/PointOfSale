namespace PointOfSale.App.Models;

public sealed class PurchaseOrder
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string VendorName { get; set; } = string.Empty;
    public DateTime OrderedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ExpectedOn { get; set; }
    public bool IsReceived { get; set; }

    public ICollection<PurchaseOrderLine> Lines { get; set; } = new List<PurchaseOrderLine>();
}

public sealed class PurchaseOrderLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder? PurchaseOrder { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int QuantityOrdered { get; set; }
    public int QuantityReceived { get; set; }
    public decimal UnitCost { get; set; }
}
