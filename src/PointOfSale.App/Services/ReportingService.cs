using Microsoft.EntityFrameworkCore;
using PointOfSale.App.Data;
using PointOfSale.App.Models;

namespace PointOfSale.App.Services;

public sealed class ReportingService
{
    private readonly AppDbContext _dbContext;

    public ReportingService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<DailySalesSummary>> GetDailySalesSummariesAsync(DateOnly from, DateOnly to)
    {
        var start = from.ToDateTime(TimeOnly.MinValue);
        var end = to.ToDateTime(TimeOnly.MaxValue);

        var summaries = await _dbContext.Sales
            .Where(sale => sale.SoldOn >= start && sale.SoldOn <= end)
            .GroupBy(sale => DateOnly.FromDateTime(sale.SoldOn))
            .Select(group => new DailySalesSummary(
                group.Key,
                group.Sum(sale => sale.Subtotal),
                group.Sum(sale => sale.Total),
                group.Count(),
                group.SelectMany(sale => sale.LineItems).Sum(item => item.Quantity),
                group.Count() == 0 ? 0 : group.Average(sale => sale.Total),
                group.Sum(sale => sale.DiscountTotal),
                group.Sum(sale => sale.TaxTotal),
                group.Where(sale => sale.IsRefunded).Sum(sale => sale.Total)))
            .OrderBy(summary => summary.Date)
            .ToListAsync();

        return summaries;
    }

    public async Task<IReadOnlyList<InventoryOnHandSummary>> GetInventoryOnHandAsync()
    {
        return await _dbContext.InventoryItems
            .Include(item => item.Product)
            .Select(item => new InventoryOnHandSummary(
                item.ProductId,
                item.Product!.Name,
                item.QuantityOnHand,
                item.ReorderPoint,
                item.QuantityOnHand * item.Product!.Cost,
                item.Location))
            .OrderBy(summary => summary.ProductName)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<EmployeeSalesSummary>> GetEmployeeSalesAsync(DateOnly from, DateOnly to)
    {
        var start = from.ToDateTime(TimeOnly.MinValue);
        var end = to.ToDateTime(TimeOnly.MaxValue);

        return await _dbContext.Sales
            .Where(sale => sale.SoldOn >= start && sale.SoldOn <= end && sale.EmployeeId != null)
            .GroupBy(sale => sale.Employee!)
            .Select(group => new EmployeeSalesSummary(
                group.Key.Id,
                $"{group.Key.FirstName} {group.Key.LastName}",
                group.Sum(sale => sale.Total),
                group.Count(),
                group.Count() == 0 ? 0 : group.Average(sale => sale.Total),
                group.SelectMany(sale => sale.LineItems).Sum(item => item.Quantity)))
            .OrderByDescending(summary => summary.TotalSales)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<CustomerSpendSummary>> GetCustomerSpendAsync(DateOnly from, DateOnly to)
    {
        var start = from.ToDateTime(TimeOnly.MinValue);
        var end = to.ToDateTime(TimeOnly.MaxValue);

        return await _dbContext.Sales
            .Where(sale => sale.SoldOn >= start && sale.SoldOn <= end && sale.CustomerId != null)
            .GroupBy(sale => sale.Customer!)
            .Select(group => new CustomerSpendSummary(
                group.Key.Id,
                $"{group.Key.FirstName} {group.Key.LastName}",
                group.Sum(sale => sale.Total),
                group.Count(),
                group.Count() == 0 ? 0 : group.Average(sale => sale.Total)))
            .OrderByDescending(summary => summary.TotalSpend)
            .ToListAsync();
    }
}
