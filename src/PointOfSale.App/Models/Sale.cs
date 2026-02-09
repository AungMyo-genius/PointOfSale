namespace PointOfSale.App.Models;

public sealed class Sale
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime SoldOn { get; set; } = DateTime.UtcNow;
    public Guid? CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid? EmployeeId { get; set; }
    public Employee? Employee { get; set; }
    public string Location { get; set; } = "Main Store";
    public decimal Subtotal { get; set; }
    public decimal DiscountTotal { get; set; }
    public decimal TaxTotal { get; set; }
    public decimal Total { get; set; }
    public bool IsRefunded { get; set; }

    public ICollection<SaleLineItem> LineItems { get; set; } = new List<SaleLineItem>();
    public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    public ICollection<Discount> Discounts { get; set; } = new List<Discount>();
}
