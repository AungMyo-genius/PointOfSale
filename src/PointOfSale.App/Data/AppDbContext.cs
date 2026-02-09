using Microsoft.EntityFrameworkCore;
using PointOfSale.App.Models;

namespace PointOfSale.App.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<InventoryItem> InventoryItems => Set<InventoryItem>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<SaleLineItem> SaleLineItems => Set<SaleLineItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Discount> Discounts => Set<Discount>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderLine> PurchaseOrderLines => Set<PurchaseOrderLine>();
    public DbSet<GoodsReceivedNote> GoodsReceivedNotes => Set<GoodsReceivedNote>();
    public DbSet<GoodsReceivedLine> GoodsReceivedLines => Set<GoodsReceivedLine>();
    public DbSet<InventoryAdjustment> InventoryAdjustments => Set<InventoryAdjustment>();
    public DbSet<GiftCard> GiftCards => Set<GiftCard>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(product => product.Sku)
            .IsUnique();

        modelBuilder.Entity<GiftCard>()
            .HasIndex(card => card.CardNumber)
            .IsUnique();

        modelBuilder.Entity<Sale>()
            .HasMany(sale => sale.LineItems)
            .WithOne(item => item.Sale)
            .HasForeignKey(item => item.SaleId);

        modelBuilder.Entity<Sale>()
            .HasMany(sale => sale.Payments)
            .WithOne(payment => payment.Sale)
            .HasForeignKey(payment => payment.SaleId);

        modelBuilder.Entity<Sale>()
            .HasMany(sale => sale.Discounts)
            .WithOne(discount => discount.Sale)
            .HasForeignKey(discount => discount.SaleId);
    }
}
