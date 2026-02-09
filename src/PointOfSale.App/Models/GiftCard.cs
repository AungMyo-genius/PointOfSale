namespace PointOfSale.App.Models;

public sealed class GiftCard
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string CardNumber { get; set; } = string.Empty;
    public decimal InitialValue { get; set; }
    public decimal CurrentBalance { get; set; }
    public DateTime IssuedOn { get; set; } = DateTime.UtcNow;
    public DateTime? ExpiresOn { get; set; }
}
