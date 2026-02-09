namespace PointOfSale.App.Models;

public sealed class Discount
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid SaleId { get; set; }
    public Sale? Sale { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
