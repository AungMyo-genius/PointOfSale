namespace PointOfSale.App.Models;

public sealed record DailySalesSummary(
    DateOnly Date,
    decimal GrossSales,
    decimal NetSales,
    int TransactionCount,
    int UnitsSold,
    decimal AverageTransactionValue,
    decimal TotalDiscounts,
    decimal Taxes,
    decimal Refunds);

public sealed record InventoryOnHandSummary(
    Guid ProductId,
    string ProductName,
    int QuantityOnHand,
    int ReorderPoint,
    decimal InventoryValue,
    string Location);

public sealed record EmployeeSalesSummary(
    Guid EmployeeId,
    string EmployeeName,
    decimal TotalSales,
    int TransactionCount,
    decimal AverageTicket,
    int ItemsSold);

public sealed record CustomerSpendSummary(
    Guid CustomerId,
    string CustomerName,
    decimal TotalSpend,
    int VisitCount,
    decimal AverageOrderValue);
