namespace PointOfSale.App.Models;

public sealed class GoodsReceivedNote
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PurchaseOrderId { get; set; }
    public PurchaseOrder? PurchaseOrder { get; set; }
    public DateTime ReceivedOn { get; set; } = DateTime.UtcNow;
    public string ReceivedBy { get; set; } = string.Empty;
    public string? Notes { get; set; }

    public ICollection<GoodsReceivedLine> Lines { get; set; } = new List<GoodsReceivedLine>();
}

public sealed class GoodsReceivedLine
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid GoodsReceivedNoteId { get; set; }
    public GoodsReceivedNote? GoodsReceivedNote { get; set; }
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public int QuantityReceived { get; set; }
    public int QuantityRejected { get; set; }
}
