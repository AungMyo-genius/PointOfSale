namespace PointOfSale.App.Models;

public sealed class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public int LoyaltyPoints { get; set; }

    public ICollection<Sale> Sales { get; set; } = new List<Sale>();
}
