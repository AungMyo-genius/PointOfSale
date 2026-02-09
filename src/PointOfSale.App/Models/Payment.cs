namespace PointOfSale.App.Models;

public sealed class Payment
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SaleId { get; set; }
    public Sale? Sale { get; set; }
    public PaymentType PaymentType { get; set; }
    public decimal Amount { get; set; }
    public string? ReferenceNumber { get; set; }
}

public enum PaymentType
{
    Cash,
    Card,
    Mobile,
    GiftCard,
    StoreCredit
}
